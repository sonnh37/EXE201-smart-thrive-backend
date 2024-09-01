using AutoMapper;
using EXE201.SmartThrive.Domain.Entities;
using EXE201.SmartThrive.Domain.Models.Requests.Commands.Order;
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
        private void OrderMapping()
        {
            CreateMap<Order, OrderResult>().ReverseMap();
            CreateMap<Order, OrderCreateCommand>().ReverseMap();
            CreateMap<Order, OrderUpdateCommand>().ReverseMap();
        }
    }
}
