namespace TraineesAccounting.Api.Dtos
{
    public record InternshipDirectionsResponse(
        Guid Id,
        string InternshipTitle);

    public record AddInternshipDirectionRequest(
        string InternshipTitle);

    public record UpdateInternshipDirectionRequest(
        string InternshipTitle);
}
