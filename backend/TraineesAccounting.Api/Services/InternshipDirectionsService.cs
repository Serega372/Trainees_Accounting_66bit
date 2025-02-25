using AutoMapper;
using TraineesAccounting.Api.Abstract;
using TraineesAccounting.Api.Dtos;
using TraineesAccounting.Persistence.Abstract;
using TraineesAccounting.Persistence.Entities;
using TraineesAccounting.Persistence.Repositories;

namespace TraineesAccounting.Api.Services
{
    public class InternshipDirectionsService(
        IInternshipDirectionsRepository internshipDirectionsRepository,
        IMapper mapper
        ) : IInternshipDirectionsService
    {
        public async Task<List<InternshipDirectionsResponse>> All()
        {
            var internshipDirections = await internshipDirectionsRepository.All();
            return mapper.Map<List<InternshipDirectionsResponse>>(internshipDirections);
        }

        public async Task<InternshipDirectionsResponse?> GetById(Guid id)
        {
            var internshipDirection = await internshipDirectionsRepository.GetById(id)
                ?? throw new Exception($"Internship direction with id: {id} not found");
            return mapper.Map<InternshipDirectionsResponse>(internshipDirection);
        }

        public async Task<List<InternshipDirectionsResponse>> GetByPage(int page, int pageSize)
        {
            var internshipDirections = await internshipDirectionsRepository.GetByPage(page, pageSize);
            return mapper.Map<List<InternshipDirectionsResponse>>(internshipDirections);
        }

        public async Task Add(AddInternshipDirectionRequest internshipDirectionDto)
        {
            var internshipDirectionEntity = mapper.Map<InternshipDirectionEntity>(internshipDirectionDto);
            await internshipDirectionsRepository.Add(internshipDirectionEntity);
        }

        public async Task Update(Guid id, UpdateInternshipDirectionRequest updatedInternshipDirectionDto)
        {
            var currentInternshipDirection = await internshipDirectionsRepository.GetById(id)
                ?? throw new Exception($"Internship direction with id: {id} not found");

            currentInternshipDirection.InternshipTitle = updatedInternshipDirectionDto.InternshipTitle;
            await internshipDirectionsRepository.Update(currentInternshipDirection);
        }

        public async Task Delete(Guid id)
        {
            var internshipDirection = await internshipDirectionsRepository.GetById(id)
                ?? throw new Exception($"Internship direction with id: {id} not found");
            await internshipDirectionsRepository.Delete(id);
        }
    }
}
