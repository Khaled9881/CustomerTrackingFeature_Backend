using CustomerTracking.Application.Common.Exceptions;
using CustomerTracking.Application.Interfaces;
using CustomerTracking.Application.Services.Location.DTOs;
using MediatR;


namespace CustomerTracking.Application.Services.Location.Queries.GetCitiesByGovernorate
{
    public class GetCitiesByGovernorateQueryHandler : IRequestHandler<GetCitiesByGovernorateQuery, List<CityDto>>
    {
        private readonly IAppDbContext _dbContext;

        public GetCitiesByGovernorateQueryHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CityDto>> Handle(GetCitiesByGovernorateQuery request, CancellationToken cancellationToken)
        {
            var governorate = _dbContext.Governorates.FirstOrDefault(g => g.Id == request.GovernorateId);

            if (governorate == null)
            {
                throw new NotFoundException(nameof(governorate), request.GovernorateId.ToString());
            }

            return _dbContext.Cities
                .Where(c => c.GovernorateId == request.GovernorateId)
                .Select(c => new CityDto(c.Id, c.Name))
                .ToList();
        }
    }
}
