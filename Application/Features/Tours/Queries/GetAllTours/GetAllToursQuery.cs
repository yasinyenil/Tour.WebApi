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

namespace Application.Features.Tours.Queries.GetAllTours
{
    public partial class GetAllToursQuery : IRequest<PagedResponse<IEnumerable<Tour>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllTourQueryHandler : IRequestHandler<GetAllToursQuery, PagedResponse<IEnumerable<Tour>>>
    {
        private readonly ITourRepositoryAsync _tourRepository;
        private readonly IMapper _mapper;
        public GetAllTourQueryHandler(ITourRepositoryAsync tourRepository, IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<Tour>>> Handle(GetAllToursQuery request, CancellationToken cancellationToken)
        {
            var tour = await _tourRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
            return new PagedResponse<IEnumerable<Tour>>(tour, request.PageNumber, request.PageSize);
        }
    }
}
