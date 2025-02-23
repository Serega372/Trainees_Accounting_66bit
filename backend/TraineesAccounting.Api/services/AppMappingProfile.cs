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
        }
    }
}
