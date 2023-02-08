using AutoMapper;
using TestTaskHoH.Mapping;
using TestTaskHoH.Commands;

namespace TestTaskHoH.Models
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        public string Title { get; set; }
        public string Info { get; set; }
  
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Info,
                    opt => opt.MapFrom(noteDto => noteDto.Info));

        }
    }
}
