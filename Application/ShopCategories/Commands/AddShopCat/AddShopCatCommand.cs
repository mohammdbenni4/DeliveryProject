using Discord.Net;
using Domain.Models;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Elkood.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.ShareMethods;

namespace Application.ShopCategories.Commands.AddShopCat
{
    public class AddShopCatCommand
    {
        public class Request : IRequest<OperationResponse<Response>>
        {
            public LanguageProperty? Name { get; set; }
        }
        public class Response
        {
            public Guid Id { get; set; }
            public string? Name { get; set; }

            public static Expression<Func<ShopCategory, Response>> Selector(string lang)
               => a => new()
               {
                   Id = a.Id,
                   Name = a.Name.GetByLanguage(lang),
               };
        }
    }
}
