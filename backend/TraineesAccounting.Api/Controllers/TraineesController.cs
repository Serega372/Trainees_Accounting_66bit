using Microsoft.AspNetCore.Mvc;
using TraineesAccounting.Api.Abstract;
using TraineesAccounting.Api.Dtos;

namespace TraineesAccounting.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TraineesController(
        ITraineesService traineesService
        ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TraineesResponse>>> All()
        {
            var trainees = await traineesService.All();
            return Ok(trainees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TraineesResponse>> GetById([FromRoute] Guid id)
        {
            var trainee = await traineesService.GetById(id);
            return Ok(trainee);
        }

        [HttpGet("{page};{pageSize}")]
        public async Task<ActionResult<List<TraineesResponse>>> GetByPage(
            [FromRoute] int page,
            [FromRoute] int pageSize
            )
        {
            var trainees = await traineesService.GetByPage(page, pageSize);
            return Ok(trainees);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddTraineeRequest traineeDto)
        {
            await traineesService.Add(traineeDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateTraineeRequest traineeDto
            )
        {
            await traineesService.Update(id, traineeDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await traineesService.Delete(id);
            return Ok();
        }
    }
}