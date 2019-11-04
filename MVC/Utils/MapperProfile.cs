using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using MVC.Models;

namespace MVC.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookModel>()
                .ReverseMap();
            CreateMap<Tag, TagModel>().ReverseMap();

            CreateMap<Order, OrderViewModel>().ForMember(dest => dest.Book, src => src.MapFrom(x => x.Education.BookModel));
            CreateMap<OrderViewModel, Order>().ForMember(dest => dest.BookModel, src => src.MapFrom(x => x.Education.Book));
        }
    }
}
