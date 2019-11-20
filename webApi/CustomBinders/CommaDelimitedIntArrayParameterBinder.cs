using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace webApi.CustomBinders
{
    public class CommaDelimitedIntArrayParameterBinder : IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {

            var value = bindingContext.ActionContext.RouteData.Values[bindingContext.FieldName] as string;

            // Check if the argument value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            var ints = value?.Split(',').Select(int.Parse).ToArray();

            bindingContext.Result = ModelBindingResult.Success(ints);

            if (bindingContext.ModelType == typeof(List<int>))
            {
                bindingContext.Result = ModelBindingResult.Success(ints.ToList());
            }

            return Task.CompletedTask;
        }
    }
}