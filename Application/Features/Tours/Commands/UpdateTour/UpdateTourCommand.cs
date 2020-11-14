using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Tours.Commands.UpdateTour
{
    public class UpdateTourCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FromWhere { get; set; }
        public string ToWhere { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int NumberOfSeats { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, Response<int>>
        {
            private readonly ITourRepositoryAsync _tourRepository;
            public UpdateTourCommandHandler(ITourRepositoryAsync tourRepository)
            {
                _tourRepository = tourRepository;
            }
            public async Task<Response<int>> Handle(UpdateTourCommand command, CancellationToken cancellationToken)
            {
                var tour = await _tourRepository.GetByIdAsync(command.Id);

                if (tour == null)
                {
                    throw new ApiException($"Tour Not Found.");
                }
                else
                {
                    tour.Name = command.Name;
                    tour.ArrivalDate = command.ArrivalDate;
                    tour.FromWhere = command.FromWhere;
                    tour.ToWhere = command.ToWhere;
                    tour.StartDate = command.StartDate;
                    tour.NumberOfSeats = command.NumberOfSeats;
                    tour.Notes = command.Notes;
                    tour.Status = command.Status;
                    tour.Description = command.Description;
                    await _tourRepository.UpdateAsync(tour);
                    return new Response<int>(tour.Id);
                }
            }
        }
    }
}