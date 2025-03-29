using MediatR;
using Microsoft.AspNetCore.Mvc;
using Net.Clinic.API.Contracts.Appointments;
using Net.Clinic.Application.Features.Appointments.Create;
using Net.Clinic.Application.Features.Appointments.Delete;
using Net.Clinic.Application.Features.Appointments.FetchCurrentDate;
using Net.Clinic.Application.Features.Appointments.UpdateAssist;

namespace Net.Clinic.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateaAppointment([FromBody] CreateAppoinrtmentContract contract)
        {
            var command = new CreateAppointmentCommand(contract.PatientName, contract.Identification, contract.DateSelected);
            var result = await this._mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, result.Errors);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment([FromBody] DeleteAppointmentContract contract)
        {
            var command = new DeleteAppointmentCommand(contract.AppointmentId);
            var result = await this._mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound(result.Errors);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAppointmentAssist([FromBody] UpdateAppointmentAssistContract contract)
        {
            var command = new UpdateAppointmentAssistCommand(contract.AppointmentId);
            var result = await this._mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return NotFound(result.Errors);
            }
        }

        [HttpPost]
        public async Task<IActionResult> FetchAppointmentsByCurrentDate([FromBody] FetchAppointmentByCurrentDateContract contract)
        {
            var query = new FetchCurrentDateAppointmentQuery(contract.CurrentDate);
            var result = await this._mediator.Send(query);
            return Ok(result.Data);
        }
    }
}