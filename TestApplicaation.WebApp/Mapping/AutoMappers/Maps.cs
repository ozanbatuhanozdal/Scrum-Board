using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Common.Dto.CustomerCardDtos;
using TestApplication.Common.Dto.CustomerCardRowDtos;
using TestApplication.Common.Dto.CustomerDtos;
using TestApplication.Common.Dto.UserDtos;
using TestApplication.Common.Dto.UserTypeDtos;
using TestApplication.Entities;
using TestApplication.Entities.Models;

namespace TestApplication.WebApp.Mapping.AutoMappers
{
    //bu clası profileden kalıtsal yollarla getirmemiz gerekiyor
    public class Maps : Profile
    {
        public Maps()
        {
            //DTO (Data Transfer Object) ise AutoMapper’ın dönüştürmesini istediğimiz format modelidir.

            // AutoMapper, projemizde Entity nesnelerini database’den çektiğimiz haliyle değil, 
            //bu nesneleri istediğimiz(UI’da bizim için gerekli olacak) 
            // formata çevirmemizi sağlayan basit bir kütüphanedir. 


            //customerı customerDtoya çevirecek.
            CreateMap<Customer, CustomerAddDto>();
            //tam tersi işlem
            CreateMap<CustomerAddDto, Customer>();

            //customer<-->CustomerListDto
            CreateMap<Customer, CustomerListDto>();
            CreateMap<CustomerListDto, Customer>();

            //Customer<-->customerUpdate
            CreateMap<Customer, CustomerUpdateDto>();
            CreateMap<CustomerUpdateDto, Customer>();

            //customer <--> CustomerDeleteDto>
            CreateMap<Customer, CustomerDeleteDto>();
            CreateMap<CustomerDeleteDto, Customer>();

            //customerCar <--> CustomerCardAddDto>
            CreateMap<CustomerCard, CustomerCardAddDto>();
            CreateMap<CustomerCardAddDto, CustomerCard>();


            //customerCardRow<-->CustomerCardRowAddDto
            CreateMap<CustomerCardRow, CustomerCardRowAddDto>();
            CreateMap<CustomerCardRowAddDto, CustomerCardRow>();


            //userı userListDtoya çevirebilecek
            CreateMap<User, UserListDto>();
            //ve tam tersi iş
            CreateMap<UserListDto, User>();

            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();

            //UserType<-->UserTypeDto
            CreateMap<UserType, UserTypeDto>();
            CreateMap<UserTypeDto, UserType>();

            //UserUserType<-->UserTypeDto
            CreateMap<UserUserType, UserTypeDto>();
            CreateMap<UserTypeDto, UserUserType>();

            //UserAddDto<-->User
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserAddDto>();

            //UserRegisterDto<-->User
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserRegisterDto>();

            //userType<-->UserTypeAddDto
            CreateMap<UserType, UserTypeAddDto>();
            CreateMap<UserTypeAddDto, UserType>();

            //UserTpeDto<-->UserType
            CreateMap<UserTypeUpdateDto, UserType>();
            CreateMap<UserType, UserTypeUpdateDto>();


        }
    }
}
