using AutoMapper;
using EmailNotifier.Application.Common.Mappings;
using EmailNotifier.Application.MailStatus.Command.CreateMailStatus;

namespace EmailNotifier.WebAPI.Models.MailStatus;

public class CreateMailStatusDto : IMapWith<CreateMailStatusCommand>
{
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateMailStatusDto, CreateMailStatusCommand>()
            .ForMember(ms => ms.Name,
            msdto => msdto.MapFrom(ms => ms.Name));
    }

}
