namespace TraineesAccounting.Api.Dtos
{
    public record TraineesResponse(
        Guid Id,
        string Name,
        string Surname,
        string Gender,
        string Email,
        string? PhoneNumber,
        DateOnly Birthday,
        string? InternshipTitle,
        string? ProjectTitle,
        Guid? InternshipDirectionId,
        Guid? ProjectId);

    public record AddTraineeRequest(
        string Name,
        string Surname,
        string Gender,
        string Email,
        string? PhoneNumber,
        DateOnly Birthday,
        Guid InternshipDirectionId,
        Guid ProjectId);

    public record UpdateTraineeRequest(
        string Name,
        string Surname,
        string Gender,
        string Email,
        string? PhoneNumber,
        DateOnly Birthday,
        Guid InternshipDirectionId,
        Guid ProjectId);
}
