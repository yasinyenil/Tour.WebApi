using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Tours.Commands
{

    public partial class CreateTourCommand : IRequest<Response<int>>
    {
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
    }
    public class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, Response<int>>
    {
        private readonly ITourRepositoryAsync _tourRepository;
        private readonly IMapper _mapper;
        public CreateTourCommandHandler(ITourRepositoryAsync tourRepository, IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = _mapper.Map<Tour>(request);
            await _tourRepository.AddAsync(tour);
            return new Response<int>(tour.Id);
        }
    }
}
