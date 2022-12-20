using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTestDDD.Application.Vehicle.Commands.DeleteVehicle;
using TechTestDDD.Application.Vehicle.Commands.InsertVehicle;
using TechTestDDD.Application.Vehicle.Common;
using TechTestDDD.Application.Vehicle.Queries.GetFirst;
using TechTestDDD.Application.Vehicle.Queries.GetList;
using TechTestDDD.Contracts.Vehicle;
using TechTestDDD.Domain.Common.Errors;

namespace TechTestDDD.Api.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public VehicleController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene la lista de todos los vehiculos
        /// </summary>
        /// <returns>Lista de vehiculos</returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> ListVehicles()
        {
            GetListRequest request = new GetListRequest();

            var query = _mapper.Map<GetListQuery>(request);

            ErrorOr<VehicleListResult> vehResult = await _mediator.Send(query);

            return vehResult.Match(
                vehResult => Ok(_mapper.Map<VehicleListResponse>(vehResult)),
                errors => Problem(errors)
            );
        }

        /// <summary>
        /// Obtiene el detalle de un registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Retorna el detalle del registro de un vehiculo</returns>
        [HttpGet("GetVehicle")]
        public async Task<IActionResult> GetVehicle([FromQuery] GetFirstRequest request)
        {
            var query = _mapper.Map<GetFirstQuery>(request);

            ErrorOr<VehicleResult> vehResult = await _mediator.Send(query);

            if (vehResult.IsError && vehResult.FirstError == Errors.Vehicle.Validation)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                        title: vehResult.FirstError.Description);
            }

            return vehResult.Match(
                vehResult => Ok(_mapper.Map<VehicleResponse>(vehResult)),
                errors => Problem(errors)
            );

        }

        /// <summary>
        /// Agrega un  nuevo registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Retorna el detalle del nuevo registro creado</returns>
        [HttpPost("CreateVehicle")]
        public async Task<IActionResult> CreateVehicle([FromBody] InsertVehicleRequest request)
        {
            var command = _mapper.Map<InsertVehicleCommand>(request);

            ErrorOr<VehicleResult> vehResult = await _mediator.Send(command);

            if (vehResult.IsError && vehResult.FirstError == Errors.Vehicle.Validation)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                        title: vehResult.FirstError.Description);
            }

            return vehResult.Match(
                vehResult => Ok(_mapper.Map<VehicleResponse>(vehResult)),
                errors => Problem(errors)
            );
        }

        /// <summary>
        /// Actualiza un regitro
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Retorna el registro actualizado.</returns>
        [HttpPut("UpdateVehicle")]
        public async Task<IActionResult> UpdateVehicle([FromBody] UpdateVehicleRequest request)
        {
            var command = _mapper.Map<UpdateVehicleCommand>(request);

            ErrorOr<VehicleResult> vehResult = await _mediator.Send(command);

            if (vehResult.IsError && vehResult.FirstError == Errors.Vehicle.Validation)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                        title: vehResult.FirstError.Description);
            }

            return vehResult.Match(
                vehResult => Ok(_mapper.Map<VehicleResponse>(vehResult)),
                errors => Problem(errors)
            );
        }

        /// <summary>
        /// Elimina un registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("DeleteVehicle")]
        public async Task<IActionResult> DeleteVehicle([FromQuery] DeleteVehicleRequest request)
        {
            var command = _mapper.Map<DeleteVehicleCommand>(request);

            ErrorOr<VehicleResult> vehResult = await _mediator.Send(command);

            if (vehResult.IsError && vehResult.FirstError == Errors.Vehicle.Validation)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                        title: vehResult.FirstError.Description);
            }

            return vehResult.Match(
                vehResult => NoContent(),
                errors => Problem(errors)
            );
        }
    }
}
