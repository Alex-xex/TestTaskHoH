using AutoMapper;
using System;
using TestTaskHoH.Mapping;
using TestTaskHoH.Commands;

namespace TestTaskHoH.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public bool Actual { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Info,
                    opt => opt.MapFrom(noteDto => noteDto.Info))
                .ForMember(noteCommand => noteCommand.Actual,
                    opt => opt.MapFrom(noteDto => noteDto.Actual));
        }
    }
}
