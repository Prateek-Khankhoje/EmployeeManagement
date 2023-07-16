using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagement.DataAccessservice.Filters
{
    public class DelayFilter : IAsyncActionFilter
    {
        private int _delay;
        public DelayFilter(IConfiguration config)
        {
            _delay = config.GetValue<int>("Delay",0);
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(_delay > 0)
                await Task.Delay(_delay);
            await next();
        }
    }
}
