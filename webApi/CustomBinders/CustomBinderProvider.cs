using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace webApi.CustomBinders
{
    public class CustomBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new System.ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(int[]) || context.Metadata.ModelType == typeof(List<int>))
            {
                return new BinderTypeModelBinder(typeof(CommaDelimitedIntArrayParameterBinder));
            }

            if (context.Metadata.ModelType == typeof(string[]) || context.Metadata.ModelType == typeof(List<string>))
            {
                return new BinderTypeModelBinder(typeof(CommaDelimitedStringArrayParameterBinder));
            }

            return null;
        }
    }
}