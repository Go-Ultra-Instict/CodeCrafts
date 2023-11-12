using Application.StudentTopic.Queries.GetStudents;
using AutoMapper;
using CodeCrafts.Domain.Entities;


namespace Application.Mappings;

public class AutoMapperProfileRegister : Profile
{
    public AutoMapperProfileRegister()
    {
        CreateMap<Student, StudentDto>()
            .ForMember(dest => dest.Name2, opt => opt.MapFrom(src => src.Name)).ReverseMap();

    }
}
