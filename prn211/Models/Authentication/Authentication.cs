﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace prn211.Models.Authentication
{
	public class Authentication: ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (context.HttpContext.Session.GetString("UserName") == null)
			{
				context.Result = new RedirectToRouteResult(new RouteValueDictionary
				{
					{ "controller", "Login" },
					{ "action", "Index" }
				});
			}
			base.OnActionExecuting(context);
		}
	}
}
