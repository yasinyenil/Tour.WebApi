using Application.Features.Reservations.Commands.CreateReservation;
using Application.Features.Tours.Commands;
using Application.Features.Tours.Queries.GetAllTours;
using Application.Features.Tours.Queries.GetAllToursByTourDestination;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            
            CreateMap<CreateTourCommand, Tour>();
            CreateMap<GetAllToursQuery, GetAllTourParameter>();
            CreateMap<GetAllToursByTourDestinationQuery,GetAllTourSearchParameter>();

            CreateMap<CreateReservationCommand, Reservation>();

        }
    }
}
