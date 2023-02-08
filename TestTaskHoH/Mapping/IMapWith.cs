using AutoMapper;

namespace TestTaskHoH.Mapping
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
                   profile.CreateMap(typeof(T), GetType());
    }
}
