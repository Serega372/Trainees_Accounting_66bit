using Microsoft.AspNetCore.Mvc;
using TraineesAccounting.Api.Abstract;
using TraineesAccounting.Api.Dtos;

namespace TraineesAccounting.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController(
        IProjectsService projectsService
        ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ProjectsResponse>>> All()
        {
            var projects = await projectsService.All();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectsResponse>> GetById([FromRoute] Guid id)
        {
            var project = await projectsService.GetById(id);
            return Ok(project);
        }

        [HttpGet("{page};{pageSize}")]
        public async Task<ActionResult<List<ProjectsResponse>>> GetByPage(
            [FromRoute] int page,
            [FromRoute] int pageSize
            )
        {
            var projects = await projectsService.GetByPage(page, pageSize);
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddProjectRequest projectDto)
        {
            await projectsService.Add(projectDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateProjectRequest projectDto
            )
        {
            await projectsService.Update(id, projectDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await projectsService.Delete(id);
            return Ok();
        }
    }
}
