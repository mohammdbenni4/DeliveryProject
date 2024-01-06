using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.ShareMethods;

namespace Application.ShopCategories.Queries.GetAllCat
{
    public class GetAllCatQuery 
    {
        public class Request : IRequest<OperationResponse<Response>>
        {

        }

        public class Response
        {
            public List<ShopCategoryDto> ShopCategories { get; set; }
            public class ShopCategoryDto
            {
                public Guid Id { get; set; }
                public string? Name { get; set; }
            }

            public static Expression<Func<ShopCategory, ShopCategoryDto>> Selector(string lang)
                => a => new()
                {
                    Id = a.Id,
                    Name = a.Name.GetByLanguage(lang),
                };
        }
    }
}
