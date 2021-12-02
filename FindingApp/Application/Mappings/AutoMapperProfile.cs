using System.Reflection.Metadata.Ecma335;
using System;
using AutoMapper;
using FindingApp.Domain.Dtos.Responses;
using FindingApp.Domain.Dtos.Requests;
using FindingApp.Domain.Entities;

namespace FindingApp.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TblTournament, TorneosResponse>();

           CreateMap<TorneosCreateRequest, TblTournament>();           
        }
    }
}