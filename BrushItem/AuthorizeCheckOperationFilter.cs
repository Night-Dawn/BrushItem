using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrushItem
{
    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //获取是否添加登录特性
            //策略名称映射到范围
            var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any()
            || context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            if (hasAuthorize)
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "未经授权" });
                operation.Responses.Add("403", new OpenApiResponse { Description = "禁止访问" });
                //operation.Security = new List<IDictionary<string, IEnumerable<string>>>
                //{
                //    new Dictionary<string,IEnumerable<string>>{{ "oauth2", new[] { "brushitem.api" }}}
                //};
                var oAuthScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                };

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [ new OpenApiSecurityScheme 
                        { 
                            Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"}
                        } 
                        ] = new []{ "api1" }
                    }
                };
            }
        }
    }
}
