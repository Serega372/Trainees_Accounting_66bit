using AutoMapper;
using TraineesAccounting.Api.Abstract;
using TraineesAccounting.Api.Dtos;
using TraineesAccounting.Persistence.Abstract;
using TraineesAccounting.Persistence.Entities;

namespace TraineesAccounting.Api.Services
{
    public class TraineesService(
        ITraineesRepository traineesRepository,
        IInternshipDirectionsRepository internshipDirectionsRepository,
        IProjectsRepository projectsRepository,
        IMapper mapper
        ) : ITraineesService
    {
        public async Task<List<TraineesResponse>> All()
        {
            var trainees = await traineesRepository.All();
            return mapper.Map<List<TraineesResponse>>(trainees);
        }

        public async Task<TraineesResponse> GetById(Guid id)
        {
            var trainee = await traineesRepository.GetById(id)
                ?? throw new Exception($"Trainee with id: {id} not found");
            return mapper.Map<TraineesResponse>(trainee);
        }

        public async Task<List<TraineesResponse>> GetByPage(int page, int pageSize)
        {
            var trainees = await traineesRepository.GetByPage(page, pageSize);
            return mapper.Map<List<TraineesResponse>>(trainees);
        }

        public async Task Add(AddTraineeRequest traineeDto)
        {
            var internshipDirection = await internshipDirectionsRepository
                .GetById(traineeDto.InternshipDirectionId)
                ?? throw new Exception(
                    $"Internship direction with id: " +
                    $"{traineeDto.InternshipDirectionId} not found");

            var project = await projectsRepository
                .GetById(traineeDto.ProjectId)
                ?? throw new Exception(
                    $"Project with id: " +
                    $"{traineeDto.ProjectId} not found");

            var traineeEntity = mapper.Map<TraineeEntity>(traineeDto);
            traineeEntity.InternshipTitle = internshipDirection.InternshipTitle;
            traineeEntity.ProjectTitle = project.ProjectTitle;
            await traineesRepository.Add(traineeEntity);
        }

        public async Task Update(Guid id, UpdateTraineeRequest updatedTraineeDto)
        {
            var currentTrainee = await traineesRepository.GetById(id)
                ?? throw new Exception($"Trainee with id: {id} not found");

            currentTrainee.Name = updatedTraineeDto.Name;
            currentTrainee.Surname = updatedTraineeDto.Surname;
            currentTrainee.Gender = updatedTraineeDto.Gender;
            currentTrainee.Email = updatedTraineeDto.Email;
            currentTrainee.PhoneNumber = updatedTraineeDto.PhoneNumber;
            currentTrainee.Birthday = updatedTraineeDto.Birtday;

            if (currentTrainee.InternshipDirectionId
                != updatedTraineeDto.InternshipDirectionId)
            {
                var internshipDirection = await internshipDirectionsRepository
                    .GetById(updatedTraineeDto.InternshipDirectionId)
                    ?? throw new Exception(
                        $"Internship direction with id: " +
                        $"{updatedTraineeDto.InternshipDirectionId} not found");

                currentTrainee.InternshipDirectionId = updatedTraineeDto.InternshipDirectionId;
                currentTrainee.InternshipTitle = internshipDirection.InternshipTitle;
            };

            if (currentTrainee.ProjectId
                != updatedTraineeDto.ProjectId)
            {
                var project = await projectsRepository
                    .GetById(updatedTraineeDto.ProjectId)
                    ?? throw new Exception($"Project with id: " +
                    $"{updatedTraineeDto.ProjectId} not found");

                currentTrainee.ProjectId = updatedTraineeDto.ProjectId;
                currentTrainee.ProjectTitle = project.ProjectTitle;
            }

            await traineesRepository.Update(currentTrainee);
        }

        public async Task Delete(Guid id)
        {
            var trainee = await traineesRepository.GetById(id)
                ?? throw new Exception($"Trainee with id: {id} not found");
            await traineesRepository.Delete(id);
        }
    }
}