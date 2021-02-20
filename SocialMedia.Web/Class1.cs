using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.Web
{
    public class Class1
    {
        //[HttpPost]
        //public JsonResult CountryCity(int? countryId, int? categoryId, string tip)
        //{
        //    var countryList = _countryService.GetAllIncluding().Where(i => i.IsConfirmed == true).OrderByDescending(i => i.CreatedDate).ToList();
        //    var cityList = _cityService.GetAllIncluding().Where(i => i.CountryId == countryId && i.IsConfirmed == true).OrderByDescending(i => i.CreatedDate).ToList();
        //    var categoryList = _categoryService.GetAllIncluding().Where(i => i.IsConfirmed == true).OrderByDescending(i => i.CreatedDate).ToList();
        //    var subcategoryList = _subcategoryService.GetAllIncluding().Where(i => i.CategoryId == categoryId && i.IsConfirmed == true).OrderByDescending(i => i.CreatedDate).ToList();

        //    List<SelectListItem> sonuc = new List<SelectListItem>();
        //    bool basariliMi = true;
        //    try
        //    {
        //        switch (tip)
        //        {
        //            case "GetCountry":
        //                foreach (var item in countryList)
        //                {
        //                    sonuc.Add(new SelectListItem
        //                    {
        //                        Text = item.Name,
        //                        Value = item.Id.ToString()
        //                    });
        //                }
        //                break;
        //            case "GetCity":
        //                foreach (var item in cityList)
        //                {
        //                    sonuc.Add(new SelectListItem
        //                    {
        //                        Text = item.Name,
        //                        Value = item.Id.ToString()
        //                    });
        //                }
        //                break;

        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        basariliMi = false;
        //        sonuc = new List<SelectListItem>();
        //        sonuc.Add(new SelectListItem
        //        {
        //            Text = "Bir hata oluştu :(",
        //            Value = "Default"
        //        });
        //    }
           
        //    return Json(new { ok = basariliMi, text = sonuc });
        //}
    }
}