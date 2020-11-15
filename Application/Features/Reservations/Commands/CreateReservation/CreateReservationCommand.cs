using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.CreateReservation
{
    public partial class CreateReservationCommand : IRequest<Response<int>>
    {
        public int TourId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerPhone { get; set; }
        public int NumberOfPerson { get; set; }
        public bool IsActive { get; set; }

        public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Response<int>>
        {
            private readonly IReservationRepositoryAsync _reservationRepository;
            private readonly ITourRepositoryAsync _tourRepository;
            private readonly IMapper _mapper;

            public CreateReservationCommandHandler(IReservationRepositoryAsync reservationRepository, ITourRepositoryAsync tourRepository, IMapper mapper)
            {
                _reservationRepository = reservationRepository;
                _tourRepository = tourRepository;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
            {
                var numberOfSeats = _tourRepository.GetByIdAsync(request.TourId).GetAwaiter().GetResult().NumberOfSeats;

                var listReservation = _reservationRepository.GetAllAsync(x => x.TourId == request.TourId).GetAwaiter().GetResult();

                int sum = 0;
                int total = 0;
                foreach (var item in listReservation)
                {
                     sum = sum + item.NumberOfPerson;
                }
                total = sum + request.NumberOfPerson;
                if (sum >= numberOfSeats)
                {
                    throw new ApiException($"All seats are occupied.");
                }
                else if (total > numberOfSeats )
                {
                    throw new ApiException($"Reserves cannot be made more than the appropriate seat number.");
                }

                var reservation = _mapper.Map<Reservation>(request);
                await _reservationRepository.AddAsync(reservation);
                return new Response<int>(reservation.Id);
            }
        }
    }
}
