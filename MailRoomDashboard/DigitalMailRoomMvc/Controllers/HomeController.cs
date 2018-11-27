using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigitalMailRoomMvc.Models;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json;
using System.Text;

namespace DigitalMailRoomMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FullList()
        {
            return View(claimList);
        }

        public IActionResult Validation()
        {
            ViewData["Message"] = "Your validation page.";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly IList claimList = new ArrayList()
        {
            new ClaimEntity{ ClaimId=457898,PatientId=54443,ColumnsToVerify=6,ConfidenceScore=80,SubmissionDate=new DateTime(2018,06,15),ExtractedDate=DateTime.Today}
        };

        //[HttpGet]
        //public ActionResult Load(String sort, String order, String search, Int32 limit, Int32 offset)
        //{
        //    // Get entity fieldnames
        //    List<String> columnNames = typeof(ClaimEntity).GetProperties(BindingFlags.Public |
        //                               BindingFlags.Instance).Select(p => p.Name).ToList();

        //    // Create a separate list for searchable field names   
        //    List<String> searchFields = new List<String>(columnNames);

        //    // Exclude field Iso2 for filtering 
        //    searchFields.Remove("ISO2");

        //    // Perform filtering
        //    IQueryable<ClaimEntity> items = SearchItems(claimList.AsQueryable<ClaimEntity>, search, searchFields);

        //    // Sort the filtered items and apply paging
        //    return Content(ItemsToJson
        //    (items, columnNames, sort, order, limit, offset), "application/json");
        //}

        //protected String ItemsToJson(IQueryable items, List<String> columnNames, String sort, String order, Int32 limit, Int32 offset)
        //{
        //    try
        //    {
        //        // where clause is set, count total records
        //        Int32 count = items.Count();

        //        // Skip requires sorting, so make sure there is always sorting
        //        String sortExpression = "";

        //        if (sort != null && sort.Length > 0)
        //            sortExpression += String.Format("{0} {1}", sort, order);

        //        // show all records if limit is not set
        //        if (limit == 0)
        //            limit = count;

        //        // Prepare json structure
        //        var result = new
        //        {
        //            total = count,
        //            rows = items.OrderBy(sortExpression).Skip(offset).Take(limit).Select("new (" + String.Join(",", columnNames) + ")")
        //        };

        //        return JsonConvert.SerializeObject(result, Formatting.None, new JsonSerializerSettings() { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}


        //// needs System.Linq.Dynamic.Core
        //protected IQueryable SearchItems(IQueryable<ClaimEntity> items, String search, List<String> columnNames)
        //{
        //    // Apply filtering to all visible column names
        //    if (search != null && search.Length > 0)
        //    {
        //        StringBuilder sb = new StringBuilder();

        //        // create dynamic Linq expression
        //        foreach (String fieldName in columnNames)
        //            sb.AppendFormat("({0} == null ? false : {0}.ToString().IndexOf(@0, @1) >=0) or {1}", fieldName, Environment.NewLine);

        //        String searchExpression = sb.ToString();
        //        // remove last "or" occurrence
        //        searchExpression = searchExpression.Substring(0, searchExpression.LastIndexOf("or"));

        //        // Apply filtering, 
        //        items = items.Where(searchExpression, search, StringComparison.OrdinalIgnoreCase);
        //    }

        //    return items;
        //}
    }
}
