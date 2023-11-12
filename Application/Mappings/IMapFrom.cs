using AutoMapper;

namespace Application.Mappings;

//Todo Learn this approch
public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
