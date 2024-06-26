﻿using ASP_WebApi_Edu.Extensions;
using ASP_WebApi_Edu.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_WebApi_Edu.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        // Updates the last active timestamp for the authenticated user.
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

            var userId = resultContext.HttpContext.User.GetUserId();

            var repo = resultContext.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
            var user = await repo.GetUserByIdAsync(userId);
            user.LastActive = DateTime.UtcNow;
            await repo.SaveAllAsync();
        }
    }
}
