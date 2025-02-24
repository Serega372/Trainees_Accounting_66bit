using TraineesAccounting.Api.Dtos;

namespace TraineesAccounting.Api.Abstract
{
    public interface IInternshipDirectionsService
    {
        Task Add(AddInternshipDirectionRequest internshipDirectionDto);
        Task<List<InternshipDirectionsResponse>> All();
        Task Delete(Guid id);
        Task<InternshipDirectionsResponse?> GetById(Guid id);
        Task<List<InternshipDirectionsResponse>> GetByPage(int page, int pageSize);
        Task Update(Guid id, UpdateInternshipDirectionRequest updatedInternshipDirectionDto);
    }
}