using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTestDDD.Application.Vehicle.Common;
using TechTestDDD.Application.Vehicle.Queries.GetList;
using TechTestDDD.Contracts.Vehicle;

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
    }
}
