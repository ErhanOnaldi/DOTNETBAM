using AutoMapper;
using EduPlatform.API.DTOs;
using EduPlatform.API.Entities;

namespace EduPlatform.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Entity → DTO (API'den dönerken kullanılır)
        CreateMap<Course, CourseDto>();
        CreateMap<Category, CategoryDto>();

        // DTO → Entity (POST/PUT isteklerinde kullanılır)
        CreateMap<CreateCourseDto, Course>();
        CreateMap<UpdateCourseDto, Course>();
    }
}
