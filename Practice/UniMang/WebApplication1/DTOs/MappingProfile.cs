using AutoMapper;
using WebApplication1.Entity;

namespace WebApplication1.DTOs
    
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentCreateDTO, Student>();
            CreateMap<StudentUpdateDTO, Student>().ReverseMap();
            CreateMap<Course, CourseDTO>();
        }
    }
}
