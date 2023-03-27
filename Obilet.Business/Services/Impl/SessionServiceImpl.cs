using Microsoft.AspNetCore.Http;
using Obilet.Business.Dtos.Session;
using Obilet.Common.Clients.Obilet;
using Obilet.Common.Clients.Obilet.Constants;
using Obilet.Common.Clients.Obilet.Dtos.BusLocation;
using Obilet.Common.Clients.Obilet.Dtos.Session;
using Obilet.Common.Constants;
using Obilet.Common.Dtos;
using Obilet.Common.Services;
using Obilet.Common.Services.Impl;
using Obilet.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Services.Impl
{

    public class SessionServiceImpl : SessionService {

		private readonly ObiletClient obiletClient;
		private readonly RequestContextHolder requestContextHolder;
		private readonly CookieService cookieService;

		public SessionServiceImpl(ObiletClient obiletClient, RequestContextHolder requestContextHolder, CookieService cookieService) {

			this.obiletClient = obiletClient;
			this.requestContextHolder = requestContextHolder;
			this.cookieService = cookieService;
		}

		public async Task GetSession() {

			if (StringUtil.IsNotNullOrEmpty(cookieService.GetCookie(CookieConstant.SESSION)))
				return;

			string ipAddress = await requestContextHolder.GetRealIp();
			string port = requestContextHolder.GetRealPort();

			HttpUserAgentInfo userAgentInfo = requestContextHolder.GetBrowserInfo();

			Connection connection = new Connection(ipAddress, port);

			Browser browser = new Browser();
			if (userAgentInfo.isNotEmpty()) {
				browser.Name = userAgentInfo.BrowserName ?? "";
				browser.Version = userAgentInfo.BrowserVersion ?? "";
			}

			GetSessionReq getSessionReq = new GetSessionReq(connection, browser);

			GetSessionResp getSessionResp = await obiletClient.PostAsync<GetSessionReq, GetSessionResp>(ObiletEndpoint.GET_SESSION, getSessionReq);

			if (getSessionResp.isNotEmpty() && getSessionResp.isValid() && getSessionResp.Data != null) {
				cookieService.SetCookie(CookieConstant.SESSION, getSessionResp.Data.SessionId, ExpirationConstant.ONE_DAY);
				cookieService.SetCookie(CookieConstant.DEVICE, getSessionResp.Data.DeviceId, ExpirationConstant.ONE_DAY);
			}
		}
	}

}
