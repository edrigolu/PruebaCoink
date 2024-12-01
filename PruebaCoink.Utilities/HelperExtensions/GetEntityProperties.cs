using System.Reflection;

namespace PruebaCoink.Utilities.HelperExtensions
{
    public static class GetEntityProperties
    {
        public static Dictionary<string, object> GetPropertiesWithValues<T>(this T entity)
        {
            var properties = typeof(T).GetProperties();
            var entityParams = new Dictionary<string, object>();
            foreach (PropertyInfo propertyInfo in properties)
            {
                object value = propertyInfo.GetValue(entity)!;
                if (value is not null)
                {
                    entityParams[propertyInfo.Name] = value;
                }
            }
            return entityParams;
        }
    }
}
