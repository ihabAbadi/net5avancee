using AutoMapper;
using Shop.DTOS;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class CustomProfile : Profile
    {
        /*public CustomProfile(ICalculeComplexe _calcule)
        {
            CreateMap<Product, ProductDTO>().ForMember(cibl => cibl.PriceWithTax, or => or.MapFrom(e => _calcule.ComplexCalcule(e.Price)));
        }*/
        public CustomProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
