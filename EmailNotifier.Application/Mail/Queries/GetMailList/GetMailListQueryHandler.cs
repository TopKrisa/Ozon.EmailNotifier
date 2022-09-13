using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmailNotifier.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailNotifier.Application.Mail.Queries.GetMailList;

public class GetMailListQueryHandler : IRequestHandler<GetMailListQuery, MailListVm>
{
    private readonly IEmailNotifierContext _context;
    private readonly IMapper _mapper;

    public GetMailListQueryHandler(IEmailNotifierContext context, IMapper mapper) =>
        (_context, _mapper) = (context, mapper);

    public async Task<MailListVm> Handle(GetMailListQuery request, CancellationToken cancellationToken)
    {
        var emailsQuery = await _context.Mails
            .ProjectTo<MailLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new MailListVm() { Mails = emailsQuery };
    }
}
