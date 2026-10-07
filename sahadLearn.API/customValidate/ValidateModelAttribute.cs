using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace sahadLearn.API.customValidate
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {


        override
            public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid ==false)
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}
