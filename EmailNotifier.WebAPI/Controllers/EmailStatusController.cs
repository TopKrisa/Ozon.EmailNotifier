using AutoMapper;
using EmailNotifier.Application.MailStatus.Command.CreateMailStatus;
using EmailNotifier.WebAPI.Models.MailStatus;
using Microsoft.AspNetCore.Mvc;

namespace EmailNotifier.WebAPI.Controllers;

[ApiVersion("1.0")]
[Produces("application/json")]
[Route("api/v1/emails/status")]
public class EmailStatusController : BaseController
{
    private readonly IMapper _mapper;
    public EmailStatusController(IMapper mapper) => _mapper = mapper;
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateMailStatusDto createMailStatusDto)
    {
        var command = _mapper.Map<CreateMailStatusCommand>(createMailStatusDto);
        var vm = await Mediator.Send(command);

        return Ok(vm);
    }
}
