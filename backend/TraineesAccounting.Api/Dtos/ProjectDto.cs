namespace TraineesAccounting.Api.Dtos
{
    public record ProjectsResponse(
        Guid Id,
        string ProjectTitle);

    public record AddProjectRequest(
        string ProjectTitle);

    public record UpdateProjectRequest(
        string ProjectTitle);
}
