using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Globalization;

namespace Core.RouteConstraints
{
    public class FlatPageConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var unitOfWork = httpContext.RequestServices.GetService(typeof(IUnitOfWork)) as IUnitOfWork;

            if (values.TryGetValue(routeKey, out object pureValue) && unitOfWork != null)
            {
                var flatPageUrl = Convert.ToString(pureValue, CultureInfo.InvariantCulture);

                if (flatPageUrl == null)
                {
                    return false;
                }

                return unitOfWork.Flatpages.IsUrlExists(flatPageUrl);
            }

            return false;
        }
    }
}
