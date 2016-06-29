
using System.Collections.Specialized;
using System.Linq;

namespace cvp
{
    /// <summary>
    /// Summary description for Common
    /// </summary>
    public static class QueryStringHelper
    {
        public static string GetLang(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "lang") ? queryString["lang"].Trim() : string.Empty;
        }

        public static string GetGcpID(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "gcpid") ? queryString["gcpid"].Trim() : string.Empty;
        }
        public static string GetBrandName(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "brandname") ? queryString["brandName"].Trim() : string.Empty;
        }
        //public static string GetControlNumber(this NameValueCollection queryString)
        //{
        //    return queryString.AllKeys.Any(x => x.ToLower() == "contnum") ? queryString["contnum"].Trim() : string.Empty;
        //}
        //public static string GetRegion(this NameValueCollection queryString)
        //{
        //    return queryString.AllKeys.Any(x => x.ToLower() == "region") ? queryString["region"].Trim() : string.Empty;
        //}
        //public static string GetDrugName(this NameValueCollection queryString)
        //{
        //    return queryString.AllKeys.Any(x => x.ToLower() == "drugname") ? queryString["drugName"].Trim() : string.Empty;
        //}
        //public static string GetTrialPhase(this NameValueCollection queryString)
        //{
        //    return queryString.AllKeys.Any(x => x.ToLower() == "phase") ? queryString["phase"].Trim() : string.Empty;
        //}
        //public static string GetInsStartDate(this NameValueCollection queryString)
        //{
        //    return queryString.AllKeys.Any(x => x.ToLower() == "startdate") ? queryString["startDate"].Trim() : string.Empty;
        //}
        //public static string GetRating(this NameValueCollection queryString)
        //{
        //    return queryString.AllKeys.Any(x => x.ToLower() == "rating") ? queryString["rating"].Trim() : string.Empty;
        //}
        //public static string GetInspectionType(this NameValueCollection queryString)
        //{
        //    return queryString.AllKeys.Any(x => x.ToLower() == "instype") ? queryString["insType"].Trim() : string.Empty;
        //}
        //public static string GetDownloadExcel(this NameValueCollection queryString)
        //{
        //    return queryString.AllKeys.Any(x => x.ToLower() == "excel") ? queryString["excel"].Trim() : string.Empty;
        //}
        
    }
}