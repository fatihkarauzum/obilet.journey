using Microsoft.AspNetCore.Mvc.Filters;
using Obilet.Business.Services;

namespace Obilet.Core.Attributes {

	public class SessionAttribute : ActionFilterAttribute, IActionFilter {

		private readonly SessionService sessionService;

		public SessionAttribute(SessionService sessionService) {

			this.sessionService = sessionService;
		}

		public override void OnActionExecuting(ActionExecutingContext context) {

			sessionService.GetSession().Wait();
		}

	}

}
