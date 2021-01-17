using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobiAPI.Models;

namespace MobiAPI.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        [ActionName("GETCOUNTRYLIST")]
        [HttpGet]
        public mdlCountryListRes GETCOUNTRYLIST()
        {
            mdlCountryListRes resp = new mdlCountryListRes();
            Operation opr = new Operation();

            var List = opr.GetCountries();
            if (List!=null)
            {
                resp.StatusCode = "S";
                resp.StatusDescription = "List retrieved successfully.";
            }
            else
            {
                resp.StatusCode = "F";
                resp.StatusDescription = "Unable to fetch Countries data.";
            }
            resp.CountryData = List;
            return resp;
        }



        [ActionName("AddNewCountry")]
        [HttpPost]
        public mdlCountryListRes AddNewCountry(CountryNameCls CountryName)
        {
            mdlCountryListRes rep = new mdlCountryListRes();
            Operation opr=new Operation ();
            rep = opr.Addcountry(CountryName.CountryName);
            return rep;
        }

    }

    public class CountryNameCls
    {
        public string CountryName { get; set; }
    }


}
