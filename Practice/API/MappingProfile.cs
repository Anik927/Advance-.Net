using API2.Model;
using AutoMapper;
namespace API2    
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookCreateDTO, Book>();
            CreateMap<BookUpdateDTO, Book>();
        }
    }
}
