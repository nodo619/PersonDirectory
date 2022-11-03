using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace PersonDirectoryApi.Controllers.ActionFilters
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var stringbuilder = new StringBuilder();

                foreach (var item in context.ModelState)
                {
                    stringbuilder.Append($"\n{item.Key}: ");
                    foreach (var innerItems in item.Value.Errors)
                    {
                        stringbuilder.Append($"{innerItems.ErrorMessage} ");
                    }
                }
                throw new InvalidDataException(stringbuilder.ToString());
            }
        }
    }
}
