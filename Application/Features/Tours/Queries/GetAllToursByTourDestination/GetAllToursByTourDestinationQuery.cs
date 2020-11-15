using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Tours.Queries.GetAllToursByTourDestination
{
    //User can search their tour plan
    public partial class GetAllToursByTourDestinationQuery : IRequest<Response<IEnumerable<Tour>>>
    {
        public string FromWhere { get; set; }
        public string ToWhere { get; set; }
        public string UserId { get; set; }

        public class GetAllToursByTourDestinationQueryHandler : IRequestHandler<GetAllToursByTourDestinationQuery, Response<IEnumerable<Tour>>>
        {
            private readonly ITourRepositoryAsync _tourRepository;
            public GetAllToursByTourDestinationQueryHandler(ITourRepositoryAsync tourRepository)
            {
                _tourRepository = tourRepository;
            }
            public async Task<Response<IEnumerable<Tour>>> Handle(GetAllToursByTourDestinationQuery query, CancellationToken cancellationToken)
            {
                //var tour = await _tourRepository.GetAllAsync(x => x.FromWhere == query.FromWhere && x.ToWhere == query.ToWhere && x.CreatedBy == query.UserId);
                var tour = await _tourRepository.GetAllAsync(x => x.FromWhere == query.FromWhere && x.ToWhere == query.ToWhere);
                if (tour == null) throw new ApiException($"Tour Not Found.");
                return new Response<IEnumerable<Tour>>(tour);
            }
        }
    }
}
