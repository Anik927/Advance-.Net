using AutoMapper;
using FE53728API.Data.Entities;
using FE53728API.DTOs;

namespace FE53728API.Data
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<CourseCreateDTO, Course>();
            CreateMap<CourseUpdateDTO, Course>().ReverseMap();

            CreateMap<Batch, BatchDTO>();
            CreateMap<BatchCreateDTO, Batch>();
            CreateMap<BatchUpdateDTO, Batch>().ReverseMap();


        }

    }
}
