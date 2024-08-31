﻿using AutoMapper;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Provider;
using EXE201.SmartThrive.Domain.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.Configs.Mappings
{
    public partial class MappingProfile : Profile
    {
        private void ProviderMapping()
        {
            CreateMap<Provider, ProviderResult>().ReverseMap();
            CreateMap<Provider, ProviderCreateCommand>().ReverseMap();
            CreateMap<Provider, ProviderUpdateCommand>().ReverseMap();
        }
    }
}