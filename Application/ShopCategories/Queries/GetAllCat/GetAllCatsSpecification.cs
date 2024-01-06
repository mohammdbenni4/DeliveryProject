using Domain.Models;
using Elkood.Application.Specification;

namespace Application.ShopCategories.Queries.GetAllCat
{
    public class GetAllCatsSpecification : Specification<ShopCategory>
    {
        public GetAllCatsSpecification(GetAllCatQuery.Request request)
        {
            
        }
    }
}
