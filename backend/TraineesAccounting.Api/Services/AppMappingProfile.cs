using AutoMapper;
using TraineesAccounting.Api.Dtos;
using TraineesAccounting.Persistence.Entities;

namespace TraineesAccounting.Api.Services
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<TraineesResponse, TraineeEntity>();
            CreateMap<AddTraineeRequest,  TraineeEntity>();
            CreateMap<UpdateTraineeRequest, TraineeEntity>();
            CreateMap<TraineeEntity, TraineesResponse>();

            CreateMap<InternshipDirectionsResponse, InternshipDirectionEntity>();
            CreateMap<AddInternshipDirectionRequest, InternshipDirectionEntity>();
            CreateMap<UpdateInternshipDirectionRequest, InternshipDirectionEntity>();
            CreateMap<InternshipDirectionEntity, InternshipDirectionsResponse>();

            CreateMap<ProjectsResponse, ProjectEntity>();
            CreateMap<AddProjectRequest, ProjectEntity>();
            CreateMap<UpdateProjectRequest, ProjectEntity>();
            CreateMap<ProjectEntity, ProjectsResponse>();
        }
    }
}
