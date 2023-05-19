using AutoMapper;
using CompanySales.Application.DTOs;
using CompanySales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySales.Application.Mappings
{
    public class ModelsToDTOMappingProfile : Profile
    {
        public ModelsToDTOMappingProfile()
        {
            CreateMap<VendedorModel, VendedorDTO>().ReverseMap();
            CreateMap<ItemModel, ItemDTO>().ReverseMap();
            CreateMap<VendaModel, VendaDTO>().ReverseMap();
        }
    }
}
