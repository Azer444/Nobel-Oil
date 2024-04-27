using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Globalization;

namespace Core.RouteConstraints
{
    public class DynamicPageConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var unitOfWork = httpContext.RequestServices.GetService(typeof(IUnitOfWork)) as IUnitOfWork;

            if (values.TryGetValue(routeKey, out object pureValue) && unitOfWork != null)
            {
                var dynamicPageUrl = Convert.ToString(pureValue, CultureInfo.InvariantCulture);

                if (dynamicPageUrl == null)
                {
                    return false;
                }

                return unitOfWork.DynamicPages.IsUrlExists(dynamicPageUrl);
            }

            return false;
        }
    }
}
