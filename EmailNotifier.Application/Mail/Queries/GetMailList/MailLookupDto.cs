using AutoMapper;
using EmailNotifier.Application.Common.Mappings;

namespace EmailNotifier.Application.Mail.Queries.GetMailList;

public class MailLookupDto : IMapWith<Domain.Models.Mail>
{
    public string recipient { get; set; }
    public string subject { get; set; }
    public string text { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Models.Mail, MailLookupDto>()
            .ForMember(mailDto => mailDto.recipient,
            mail => mail.MapFrom(m => m.Recipient))
            .ForMember(mailDto => mailDto.subject,
            mail => mail.MapFrom(m => m.Subject))
            .ForMember(mailDto => mailDto.text,
            mail => mail.MapFrom(m => m.Text));
    }
}
