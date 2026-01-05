using Aplication.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Aplication.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Inmueble, InmuebleDTOs>().ReverseMap();
            CreateMap<Foto, FotoDTOs>().ReverseMap();
            CreateMap<Rol, RolDTOs>().ReverseMap();
            CreateMap<Usuario, UsuarioDTOs>().ReverseMap();
        }
    }
}
