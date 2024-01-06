using Domain.Models;
using Elkood.Application.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cities.Queries.GetAllCities
{
    public class GetAllCitiesSpecification : Specification<City>
    {
        public GetAllCitiesSpecification(GetAllCitiesQuery.Request request)
        {
            
        }
    }
}
