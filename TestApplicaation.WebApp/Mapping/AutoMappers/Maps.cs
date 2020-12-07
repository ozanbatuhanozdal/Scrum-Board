using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Common.Dto.CustomerDtos;
using TestApplication.Entities.Models;

namespace TestApplication.WebApp.Mapping.AutoMappers
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Customer, CustomerAddDto>();
            CreateMap<CustomerAddDto, Customer>();

            CreateMap<Customer, CustomerListDto>();
            CreateMap<CustomerListDto, Customer>();

            CreateMap<Customer, CustomerUpdateDto>();
            CreateMap<CustomerUpdateDto, Customer>();

            CreateMap<Customer, CustomerDeleteDto>();
            CreateMap<CustomerDeleteDto, Customer>();


        }
    }
}
