using TraineesAccounting.Api.Dtos;

namespace TraineesAccounting.Api.Abstract
{
    public interface ITraineesService
    {
        Task Add(AddTraineeRequest traineeDto);
        Task<List<TraineesResponse>> All();
        Task Delete(Guid id);
        Task<TraineesResponse> GetById(Guid id);
        Task<List<TraineesResponse>> GetByPage(int page, int pageSize);
        Task Update(Guid id, UpdateTraineeRequest updatedTraineeDto);
    }
}