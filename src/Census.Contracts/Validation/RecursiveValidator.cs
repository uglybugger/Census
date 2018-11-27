using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Census.Contracts.Validation
{
    public class RecursiveValidator
    {
        public static ValidationResult[] ValidateObject(object o)
        {
            var results = new List<ValidationResult>();
            ValidateObject(o, results);
            return results.ToArray();
        }

        private static void ValidateObject(object o, ICollection<ValidationResult> results)
        {
            if (o == null) return;

            var context = new ValidationContext(o);
            Validator.TryValidateObject(o, context, results);

            foreach (var property in PropertiesToRecurse(o))
            {
                var value = property.GetValue(o);
                ValidateObject(value, results);
            }
        }

        private static PropertyInfo[] PropertiesToRecurse(object o)
        {
            var propertiesToRecurse = o.GetType()
                                       .GetProperties()
                                       .Where(p => !p.PropertyType.IsPrimitive)
                                       .Where(p => !(p.PropertyType == typeof(string)))
                                       .ToArray();
            return propertiesToRecurse;
        }
    }
}