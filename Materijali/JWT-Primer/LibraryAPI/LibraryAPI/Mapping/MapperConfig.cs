using AutoMapper;
using LibraryAPI.DTOs;
using LibraryAPI.Models;

namespace LibraryAPI.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Book, BooksCreateRequest>().ReverseMap();
            CreateMap<Book, BooksGetDetailsResponse>().ReverseMap();
        }
    }
}
