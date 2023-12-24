using AutoMapper;
using MyNewWebSite.AccessLayer.Entity;
using MyNewWebSite.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewWebSite.AccessLayer.Context
{
    public class MyDatabaseProfile : Profile
    {
        public MyDatabaseProfile()
        {
            CreateMap<LoginModel, User>().ReverseMap();
        }
    }
}
