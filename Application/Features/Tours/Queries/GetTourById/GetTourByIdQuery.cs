using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Tours.Queries.GetTourByIdQuery
{
   public class GetTourByIdQuery : IRequest<Response<Tour>>
    {
        public int Id { get; set; }
        public class GetTourByIdQueryHandler : IRequestHandler<GetTourByIdQuery, Response<Tour>>
        {
            private readonly ITourRepositoryAsync _tourRepository;
            public GetTourByIdQueryHandler(ITourRepositoryAsync tourRepository)
            {
                _tourRepository = tourRepository;
            }

            public async Task<Response<Tour>> Handle(GetTourByIdQuery query, CancellationToken cancellationToken)
            {
                var tour = await _tourRepository.GetByIdAsync(query.Id);
                if (tour == null) throw new ApiException($"Tour Not Found.");
                return new Response<Tour>(tour);
            }
        }
    }
}
