using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MobiAPI.Models
{
    public class mdlCountryListRes
    {
        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public List<CountryList> CountryData { get; set; }
    }

    public class CountryList
    {
        public string CountryName { get; set; }
        public int IDNo { get; set; }
    }



    public class Operation
    {
        string connection = "Data Source=192.168.0.128;Initial Catalog=******;User ID=**;Password=******";
        public List<CountryList> GetCountries()
        {
            List<CountryList> resp = new List<CountryList>();
            SqlConnection sql = new SqlConnection(connection);
            sql.Open();
            SqlCommand cmd = new SqlCommand("select * from CountryList",sql);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CountryList objCountryList = new CountryList()
                {
                    CountryName = dr["CountryName"].ToString(),
                    IDNo = int.Parse(dr["IDNo"].ToString())
                };
                
                resp.Add(objCountryList);

            }
            sql.Close();
            return resp;
            
        }

        public mdlCountryListRes Addcountry(string CountryName)
        {
            mdlCountryListRes resp = new mdlCountryListRes();
            try
            {
                SqlConnection sql = new SqlConnection(connection);
                sql.Open();
                SqlCommand cmd = new SqlCommand("Insert into CountryList(CountryName) values('"+CountryName+"')", sql);
                SqlDataReader dr = cmd.ExecuteReader();
                resp.StatusCode = "S";
                resp.StatusDescription = "Country added successfully..!";
                sql.Close();
            }
            catch(Exception ex)
            {
                resp.StatusCode = "F";
                resp.StatusDescription = ex.Message;
            }

            return resp;
        }
    }
}