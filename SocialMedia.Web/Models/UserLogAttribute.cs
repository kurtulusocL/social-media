
using SocialMedia.Data.Data;
using SocialMedia.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SocialMedia.Web.Models
{
    public class UserLogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;           
            UserLog audit = new UserLog()
            {
                Id = Guid.NewGuid(),
                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                IPAddress = UserIPAddress.FindUserIp(),
                Browser = request.Browser.Browser,
                BrowserVersion = request.Browser.Version,
                Language = request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].Substring(0, 2),
                AreaAccessed = request.Url.LocalPath,
                Device = request.Browser.MobileDeviceManufacturer,
                IsMobile = request.Browser.IsMobileDevice,
                DeviceModel = request.Browser.MobileDeviceModel,
                Platform = request.Browser.Platform,
                MacAddress = PCMacAddress.GetMACAddress(),
                Date = DateTime.Now
            };

            ApplicationDbContext context = new ApplicationDbContext();
            context.UserLogs.Add(audit);
            context.SaveChanges();
            base.OnActionExecuting(filterContext);
        }
    }
}