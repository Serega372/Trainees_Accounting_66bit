using AutoMapper;
using TraineesAccounting.Api.Dtos;
using TraineesAccounting.Persistence.Abstract;

namespace TraineesAccounting.Api.Services
{
    public class InternshipDirectionsService(
        IInternshipDirectionsRepository internshipDirectionsRepository,
        IMapper mapper)
    {
        public async Task<List<InternshipDirectionsResponse>> All()
        {

        }
    }
}
