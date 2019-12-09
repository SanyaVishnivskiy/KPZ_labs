using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using MVC.Models;

namespace MVC.Utils
{
    /// <summary>
    /// Предсталяє собою профіль для автомаппера
    /// </summary>
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookModel>()
                .ReverseMap();
            CreateMap<Tag, TagModel>().ReverseMap();
        }
    }
}
