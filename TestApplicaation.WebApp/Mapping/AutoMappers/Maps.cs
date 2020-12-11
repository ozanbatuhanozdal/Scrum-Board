using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Common.Dto.CustomerDtos;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.Common.Dto.UserTypeDtos;
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

            CreateMap<User, UserListDto>();
            CreateMap<UserListDto, User>();

            CreateMap<UserType, UserTypeDto>();
            CreateMap<UserTypeDto, UserType>();

            CreateMap<UserType, UserTypeAddDto>();
            CreateMap<UserTypeAddDto, UserType>();

            CreateMap<UserTypeUpdateDto, UserType>();
            CreateMap<UserType, UserTypeUpdateDto>();


        }
    }
}
