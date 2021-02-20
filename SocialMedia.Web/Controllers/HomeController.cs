using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace SocialMedia.Web.Controllers
{
    public class HomeController : Controller
    {
        public class CaptchaResult
        {
            public class CaptchaResponse
            {
                [JsonProperty("success")]
                public bool Success { get; set; }

                [JsonProperty("error-codes")]
                public List<string> ErrorCodes { get; set; }
            }
        }
        public HomeController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SecurityAndCookie()
        {
            return View();
        }
        public ActionResult KVKH()
        {
            return View();
        }
        public ActionResult UserArgeement()
        {
            return View();
        }
        [Route("sitemap.xml")]
        public ActionResult SitemapXml()
        {
            Response.Clear();
            Response.ContentType = "text/xml";
            XmlTextWriter xr = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
            xr.WriteStartDocument();
            xr.WriteStartElement("urlset");
            xr.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            xr.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xr.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/siteindex.xsd");

            xr.WriteStartElement("url");
            xr.WriteElementString("loc", "http://localhost:44306/");
            xr.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            xr.WriteElementString("changefreq", "daily");
            xr.WriteElementString("priority", "1");
            xr.WriteEndElement();

            //var p = _adService.GetAll();
            //foreach (var b in p)
            //{
            //    xr.WriteStartElement("url");
            //    xr.WriteElementString("loc", "http://localhost:44306/Ad/" + b.Title);
            //    xr.WriteElementString("loc", "http://localhost:44306/Ad/" + b.Website);
            //    xr.WriteElementString("loc", "http://localhost:44306/Ad/" + b.CompanyName);
            //    xr.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            //    xr.WriteElementString("priority", "1");
            //    xr.WriteElementString("changefreq", "monthly");
            //    xr.WriteEndElement();
            //}
            //var zl = _videoAdService.GetAll();
            //foreach (var b in zl)
            //{
            //    xr.WriteStartElement("url");
            //    xr.WriteElementString("loc", "http://localhost:44306/VideoAd/" + b.Title);
            //    xr.WriteElementString("loc", "http://localhost:44306/VideoAd/" + b.Website);
            //    xr.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            //    xr.WriteElementString("priority", "1");
            //    xr.WriteElementString("changefreq", "monthly");
            //    xr.WriteEndElement();
            //}
           

            xr.WriteEndDocument();
            xr.Flush();
            xr.Close();
            Response.End();
            return View();
        }
    }
}