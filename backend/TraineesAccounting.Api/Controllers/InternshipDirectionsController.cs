using Microsoft.AspNetCore.Mvc;
using TraineesAccounting.Api.Abstract;
using TraineesAccounting.Api.Dtos;

namespace TraineesAccounting.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class InternshipDirectionsController(
        IInternshipDirectionsService internshipDirectionsService
        ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<InternshipDirectionsResponse>>> All()
        {
            var internshipDirections = await internshipDirectionsService.All();
            return Ok(internshipDirections);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InternshipDirectionsResponse>> GetById([FromRoute] Guid id)
        {
            var internshipDirection = await internshipDirectionsService.GetById(id);
            return Ok(internshipDirection);
        }

        [HttpGet("{page};{pageSize}")]
        public async Task<ActionResult<List<InternshipDirectionsResponse>>> GetByPage(
            [FromRoute] int page,
            [FromRoute] int pageSize
            )
        {
            var internshipDirections = await internshipDirectionsService.GetByPage(page, pageSize);
            return Ok(internshipDirections);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddInternshipDirectionRequest internshipDirectionDto)
        {
            await internshipDirectionsService.Add(internshipDirectionDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateInternshipDirectionRequest internshipDirectionDto
            )
        {
            await internshipDirectionsService.Update(id, internshipDirectionDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await internshipDirectionsService.Delete(id);
            return Ok();
        }
    }
}
