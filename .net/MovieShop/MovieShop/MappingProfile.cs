using ApplicationCore.Entities;
using ApplicationCore.Models;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Genre, GenreModel>().ReverseMap();
        CreateMap<Movie, MovieCardModel>();
    }
}