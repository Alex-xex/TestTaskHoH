using System;
using AutoMapper;
using TestTaskHoH.Entitys;
using TestTaskHoH.Mapping;


namespace TestTaskHoH.Queries
{
    public class NoteDetailsVM : IMapWith<NoteEntity>
    {

        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public bool Actual { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NoteEntity, NoteDetailsVM>()
                .ForMember(noteVM => noteVM.Title,
                    opt => opt.MapFrom(noteentity => noteentity.Title))
                .ForMember(noteVM => noteVM.Info,
                    opt => opt.MapFrom(noteentity => noteentity.Info))
                .ForMember(noteVM => noteVM.Actual,
                    opt => opt.MapFrom(noteentity => noteentity.Actual))
                .ForMember(noteVM => noteVM.CreatedDateTime,
                    opt => opt.MapFrom(noteentity => noteentity.CreatedDateTime))
                .ForMember(noteVM => noteVM.UpdatedDateTime,
                    opt => opt.MapFrom(noteentity => noteentity.UpdatedDateTime));

        }
    }
}
