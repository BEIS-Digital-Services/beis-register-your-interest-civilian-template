

namespace Beis.RegisterYourInterest.Extensions
{
    public static class ObjectExtensionMethods
    {
        public static void CopyPropertiesFrom(this object self, object parent)
        {
            var fromProperties = parent.GetType().GetProperties();
            var toProperties = self.GetType().GetProperties();

            foreach (var fromProperty in fromProperties)
            {
                foreach (var toProperty in toProperties)
                {
                    if (fromProperty.Name == toProperty.Name && fromProperty.PropertyType == toProperty.PropertyType)
                    {
                        toProperty.SetValue(self, fromProperty.GetValue(parent));
                        break;
                    }
                }
            }
        }

        public static string GetPreviousPage(this HttpRequest httpRequest)
        {
            var referrer = httpRequest.Headers["Referer"].ToString();
            var returnPage = referrer[(referrer.LastIndexOf('/') + 1)..];

            return RoutePathNameMap.Lookup.TryGetValue(returnPage, out var routeName) ? routeName : string.Empty;
        }
    }
}
