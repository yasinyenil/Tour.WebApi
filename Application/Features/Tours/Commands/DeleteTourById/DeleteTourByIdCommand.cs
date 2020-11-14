using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Tours.Commands.DeleteTourById
{
    public class DeleteTourByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteTourByIdCommandHandler : IRequestHandler<DeleteTourByIdCommand, Response<int>>
        {
            private readonly ITourRepositoryAsync _tourRepository;
            private readonly IReservationRepositoryAsync _reservationRepository;
            public DeleteTourByIdCommandHandler(ITourRepositoryAsync tourRepository, IReservationRepositoryAsync reservationRepositoryAsync)
            {
                _tourRepository = tourRepository;
                _reservationRepository = reservationRepositoryAsync;
            }
            public async Task<Response<int>> Handle(DeleteTourByIdCommand command, CancellationToken cancellationToken)
            {
                var tour = await _tourRepository.GetByIdAsync(command.Id);
                tour.IsActive = false;
                var reservations = await _reservationRepository.GetAllAsync(x=>x.TourId == command.Id);
                if (tour == null)
                {
                    throw new ApiException($"tour Not Found.");
                }
                else
                {
                    if (reservations.Count > 0)
                    {
                        // Those previously reserved are deleting.
                        // A status attribute can be added for the reason for deletion.
                        foreach (var reservation in reservations)
                        {
                            reservation.IsActive = false;
                            await _reservationRepository.DeleteAsync(reservation);
                            //TODO
                            //You can send an email for people who reserve this tour
                        }
                    }
                    await _tourRepository.DeleteAsync(tour);
                }
                return new Response<int>(tour.Id);
            }
        }
    }
}
