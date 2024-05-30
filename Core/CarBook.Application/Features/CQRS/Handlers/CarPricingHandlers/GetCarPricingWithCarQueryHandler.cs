using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
	{ 
		private readonly ICarPricingRepository _carPricingRepository;

		public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
		{
			_carPricingRepository = carPricingRepository;
		}

		public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
		{
			var values= _carPricingRepository.GetCarPricingWithCars();
			return values.Select(x => new GetCarPricingWithCarQueryResult
			{
				Amount = x.Amount,
				Brand = x.Car.Brand.Name,
				CarId = x.CarID,
				CarPricingId = x.CarPricingID,
				CoverImageUrl = x.Car.CoverImageUrl
				
			}).ToList();
		}
	}
}
