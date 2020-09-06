using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApartmentManager.Models;
using ApartmentManager.Dtos;


namespace ApartmentManager.App_Start
{
    public class MappingProfile : Profile
    {
        /* create mapping convention*/
        public MappingProfile()
        {
            Mapper.CreateMap<Property, PropertyDto>();
            Mapper.CreateMap<PropertyDto, Property>();
            Mapper.CreateMap<Apartment, ApartmentDto>();
            Mapper.CreateMap<ApartmentDto, Apartment>();
            Mapper.CreateMap<ApartmentType, ApartmentTypeDto>();
            Mapper.CreateMap<ApartmentTypeDto, ApartmentType>();
            Mapper.CreateMap<Owner, OwnerDto>();
            Mapper.CreateMap<OwnerDto, Owner>();
            Mapper.CreateMap<Tenent, TenentDto>();
            Mapper.CreateMap<TenentDto, Tenent>();



        }
    }


}