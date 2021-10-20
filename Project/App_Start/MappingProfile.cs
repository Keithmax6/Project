using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Project.Dtos;
using Project.Models;   

namespace Project.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Component, ComponentDto>();
            Mapper.CreateMap<ComponentDto, Component>();
        }
    }
}