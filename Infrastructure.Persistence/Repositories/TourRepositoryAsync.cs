using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class TourRepositoryAsync : GenericRepositoryAsync<Tour>, ITourRepositoryAsync
    {
        private readonly DbSet<Tour> _tour;

        public TourRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _tour = dbContext.Set<Tour>();
        }
    }
}
