using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace webApi.CustomBinders
{
    public class CommaDelimitedStringArrayParameterBinder : IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {

            var value = bindingContext.ActionContext.RouteData.Values[bindingContext.FieldName] as string;

            // Check if the argument value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            var strings = value?.Split(',');

            bindingContext.Result = ModelBindingResult.Success(strings);

            if (bindingContext.ModelType == typeof(List<string>))
            {
                bindingContext.Result = ModelBindingResult.Success(strings.ToList());
            }

            return Task.CompletedTask;
        }
    }
}