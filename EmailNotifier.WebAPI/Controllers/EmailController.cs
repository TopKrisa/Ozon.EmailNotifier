using AutoMapper;
using EmailNotifier.Application.Mail.Commands.CreateMail;
using EmailNotifier.Application.Mail.Queries.GetMailList;
using EmailNotifier.WebAPI.Models.Mail;
using Microsoft.AspNetCore.Mvc;

namespace EmailNotifier.WebAPI.Controllers;

[ApiVersion("1.0")]
[Produces("application/json")]
[Route("api/v1/emails")]
public class EmailController : BaseController
{
    private readonly IMapper _mapper;
    public EmailController(IMapper mapper) => _mapper = mapper;
    [HttpGet]
    public async Task<ActionResult<MailListVm>> GetAll()
    {
        var query = new GetMailListQuery();
        var vm = await Mediator.Send(query);

        return Ok(vm);
    }
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateMailDto createMailDto)
    {
        var command = _mapper.Map<CreateMailCommand>(createMailDto);
        var vm = await Mediator.Send(command);

        return Ok(vm);
    }
}
