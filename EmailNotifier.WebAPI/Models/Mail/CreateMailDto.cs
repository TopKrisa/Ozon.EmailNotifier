using AutoMapper;
using EmailNotifier.Application.Common.Mappings;
using EmailNotifier.Application.Mail.Commands.CreateMail;

namespace EmailNotifier.WebAPI.Models.Mail;

public class CreateMailDto : IMapWith<CreateMailCommand>
{
    public string recipient { get; set; }
    public string subject { get; set; }
    public string text { get; set; }
    public List<string> carbon_copy_recipients { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateMailDto, CreateMailCommand>()
            .ForMember(mc => mc.Recipient,
            mdto => mdto.MapFrom(m => m.recipient))
            .ForMember(mc => mc.Subject,
            mdto => mdto.MapFrom(m => m.subject))
            .ForMember(mc => mc.Text,
            mdto => mdto.MapFrom(m => m.text))
            .ForMember(mc => mc.CarbonCopyRecipient,
            mdto => mdto.MapFrom(m => m.carbon_copy_recipients));
    }
}
