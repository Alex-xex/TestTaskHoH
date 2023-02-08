using AutoMapper;
using TestTaskHoH.Entitys;
using TestTaskHoH.Mapping;
using System;

namespace TestTaskHoH.Queries
{
    public class GetNoteList : IMapWith<NoteEntity>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }      
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NoteEntity, GetNoteList>()
                .ForMember(noteVM => noteVM.Title,
                    opt => opt.MapFrom(noteentity => noteentity.Title))
                .ForMember(noteVM => noteVM.Id,
                    opt => opt.MapFrom(noteentity => noteentity.Id));
        }
    }
}
