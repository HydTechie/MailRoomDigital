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
using System.Web;
using DigitalMailRoomMvc.Extensions;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MailRoom.Repository.Interfaces;
using MailRoom.Model;
using Microsoft.AspNetCore.Http;
using DigitalMailRoomMvc.Constant;

namespace DigitalMailRoomMvc.Controllers
{
    public class HomeController : Controller
    {
        IStagingClaimRepository _StagingClaimRepository;

        public HomeController(IStagingClaimRepository stagingClaimsRepo)
        {
            _StagingClaimRepository = stagingClaimsRepo;
        }

        //---------------------------------------------------------------
        //--------------------------------------------------------------


        [HttpGet("Claim/{insureId}")]
        public async Task<IActionResult> StagingclaimCms1500(string insureId)
        {
            var stagingClaim = await _StagingClaimRepository.GetStagingClaimAsync(insureId);
            if (stagingClaim == null)
            {
                return NotFound();
            }
            return Ok(stagingClaim);

        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            Dashboard dashboard = await _StagingClaimRepository.GetDashboardAsync("reviewerid1");
            if (dashboard == null)
            {
                return NotFound();
            }
            // return Ok(stagingClaim);

            //Chart barChart = GenerateBarChart(dweek.DateOnXaxis, dweek.ClaimCountOnYaxis);
            ////Chart lineChart = GenerateLineChart();
            ////Chart lineScatterChart = GenerateLineScatterChart();
            ////Chart radarChart = GenerateRadarChart();
            ////Chart polarChart = GeneratePolarChart();
            ////Chart pieChart = GeneratePieChart();
            ////Chart nestedDoughnutChart = GenerateNestedDoughnutChart();
            //ViewData["BarChart"] = barChart;
            ////ViewData["LineChart"] = lineChart;
            ////ViewData["LineScatterChart"] = lineScatterChart;
            ////ViewData["RadarChart"] = radarChart;
            ////ViewData["PolarChart"] = polarChart;
            ////ViewData["PieChart"] = pieChart;
            ////ViewData["NestedDoughnutChart"] = nestedDoughnutChart;

            return View("~/Views/Home/Index.cshtml");
            //return View();
        }

        [HttpGet("DashboardWeek/{reviewerId}")]
        public async Task<IActionResult> GetDashboard(string reviewerId)
        {
            //  
            // var Dashboard = await _StagingClaimRepository.GetDashboardAsync(reviewerId);

            var Dashboard = await _StagingClaimRepository.GetDashboardByWeekAsync(reviewerId);
            if (Dashboard == null)
            {
                return NotFound();
            }
            return Ok(Dashboard);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveClaim(StagingClaimCms1500 model)
        {
            OperationStatus operationStatus = await _StagingClaimRepository.UpdatestagingClaimCms1500Async(model);
            if (ModelState.IsValid)
            {

            }
            if (operationStatus.Status != true)
            {
                model.ParserErrorCsv = operationStatus.Message;
                ViewBag.ValidationStatus = "Validation Failed";
                return View("Validation", model);
            }
            return RedirectToAction("Dashboard");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidateClaim(StagingClaimCms1500 model)
        {
            OperationStatus operationStatus = await _StagingClaimRepository.ValidatestagingClaimCms1500Async(model);
            //if (ModelState.IsValid)
            //{

            //}
            if (operationStatus.Status != true)
            {
                model.ParserErrorCsv = operationStatus.Message;
                ViewBag.ValidationStatus = "Validation Failed";
            }
            else
            {
                model.ParserErrorCsv = "[]";
                ViewBag.ValidationStatus = "Validation Success";
            }
            return View("Validation", model);

        }

        public async Task<IActionResult> Dashboard()
        {
            var Dashboard = await _StagingClaimRepository.GetDashboardAsync("reviewerId1");

            return View("Dashboard", Dashboard);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        // public async Task<IActionResult> FullList(QueryParams queryParams)
        public async Task<IActionResult> FullList(string claimType, string reviewerId, int parserStatus, string reviewStatus)
        {
            FullListEntity fullListEntity = new FullListEntity();
            fullListEntity.ClaimList = new List<GenericClaim>();
            List<GenericClaim> gridData = new List<GenericClaim>();
            if (claimType == ConstantStore.CMS1500_STRING)
            {
                IList<StagingClaimCms1500> cmsGridData = await _StagingClaimRepository.GetStagingCMSClaimsByReviewerAsync(reviewerId, parserStatus, reviewStatus);
                if (parserStatus == 2 || parserStatus == 3 || parserStatus == 4)
                {
                    fullListEntity.ClaimType = ConstantStore.CMS1500_STRING + " - " + ConstantStore.VERIFICATION_REQUIRED_STRING;
                }
                else if (parserStatus == 1)
                {
                    fullListEntity.ClaimType = ConstantStore.CMS1500_STRING + " - " + ConstantStore.ROLLBACK_STRING;
                }
                else if (parserStatus == 5)
                {
                    fullListEntity.ClaimType = ConstantStore.CMS1500_STRING + " - " + ConstantStore.OPTIONAL_VERIFICATION_STRING;
                }
                foreach (var item in cmsGridData)
                {
                    gridData.Add(new GenericClaim
                    {
                        ClaimId = item.ClaimId,
                        InsuredId = item._1aInsuredIdNumber,
                        ConfidenceScore = item.ConfidenceLevel.Value.ToString(),
                        ImportedDate = item.CreatedDate.Value.ToString(),
                        //ParserStatus = item.ParserStatus.ToString(),
                        PayerType = item._1PayerType,
                        InsurancePlanName = item._11cInsurancePlanName,
                        ReviewStatus = item.ReviewStatus,
                        //ReviewerId = item.ReviewerId
                    });
                }
                fullListEntity.ClaimList = gridData;
            }
            else if (claimType == ConstantStore.UB04_STRING)
            {
                if (parserStatus == 2 || parserStatus == 3 || parserStatus == 4)
                {
                    fullListEntity.ClaimType = ConstantStore.UB04_STRING + " - " + ConstantStore.VERIFICATION_REQUIRED_STRING;
                }
                else if (parserStatus == 1)
                {
                    fullListEntity.ClaimType = ConstantStore.UB04_STRING + " - " + ConstantStore.ROLLBACK_STRING;
                }
                else if (parserStatus == 5)
                {
                    fullListEntity.ClaimType = ConstantStore.UB04_STRING + " - " + ConstantStore.OPTIONAL_VERIFICATION_STRING;
                }
            }
            else if (claimType == ConstantStore.PK83_STRING)
            {
                if (parserStatus == 2 || parserStatus == 3 || parserStatus == 4)
                {
                    fullListEntity.ClaimType = ConstantStore.PK83_STRING + " - " + ConstantStore.VERIFICATION_REQUIRED_STRING;
                }
                else if (parserStatus == 1)
                {
                    fullListEntity.ClaimType = ConstantStore.PK83_STRING + " - " + ConstantStore.ROLLBACK_STRING;
                }
                else if (parserStatus == 5)
                {
                    fullListEntity.ClaimType = ConstantStore.PK83_STRING + " - " + ConstantStore.OPTIONAL_VERIFICATION_STRING;
                }
            }

            //if (queryParams.claimType == "UB04")
            //{
            //    IList<StagingClaimCms1500> cmsGridData = await _StagingClaimRepository.GetStagingCMSClaimsByReviewerAsync(queryParams.reviewerId, queryParams.reviewStauts);

            //    foreach (var item in cmsGridData)
            //    {
            //        gridData.Add(new GenericClaim
            //        {
            //            ClaimId = item.ClaimId,
            //            ConfidenceScore = item.ConfidenceLevel.Value.ToString(),
            //            CreatedDate = item.CreatedDate.Value.ToString(),
            //            ParserStatus = item.ParserStatus.ToString(),
            //            PayerName = item._1PayerType,
            //            ReviewStatus = item.ReviewStatus.Value.ToString(),
            //            ReviewerId = item.ReviewerId
            //        });
            //    }
            //}

            //if (queryParams.claimType == "PK83")
            //{
            //    IList<StagingClaimCms1500> cmsGridData = await _StagingClaimRepository.GetStagingCMSClaimsByReviewerAsync(queryParams.reviewerId, queryParams.reviewStauts);

            //    foreach (var item in cmsGridData)
            //    {
            //        gridData.Add(new GenericClaim
            //        {
            //            ClaimId = item.ClaimId,
            //            ConfidenceScore = item.ConfidenceLevel.Value.ToString(),
            //            CreatedDate = item.CreatedDate.Value.ToString(),
            //            ParserStatus = item.ParserStatus.ToString(),
            //            PayerName = item._1PayerType,
            //            ReviewStatus = item.ReviewStatus.Value.ToString(),
            //            ReviewerId = item.ReviewerId
            //        });
            //    }
            //}

            return View("FullList", fullListEntity);

        }

        public async Task<IActionResult> Validation(string ClaimId)
        {
            //ViewData["Message"] = "Your validation page.";
            var stagingClaim = await _StagingClaimRepository.GetStagingClaimAsync(ClaimId);
            return View("Validation", stagingClaim);
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


        //-------------------------------------------------------------------
        //-------------------------------------------------------------------

        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult AdminDashboard()
        {
            return View("AdminDashboard");
        }

        public IActionResult ServiceList()
        {

            return View("ServiceList");
        }

        public IActionResult ServiceConfiguration()
        {
            ServiceEntity obj = new ServiceEntity()
            {
                FileNamePattern = "*.*",
                RestrictFileSize = false,
                IsPollByTime = false,
                IsMoveAllowed = false,
                IsMoveErroredAllowed = false
            };
            return View("ServiceConfiguration", obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserEntity u)
        {
            // this action is for handle post (login)
            List<MenuEntity> obj = null;
            if (ModelState.IsValid) // this is check validity
            {
                if (u.Username.Equals("John") && u.Password.Equals("John123"))
                {
                    obj = new List<MenuEntity>();
                    ViewData["LoggedInRole"] = "Reviewer";
                    obj.Add(new MenuEntity() { MenuName = "Home", ActionName = "Dashboard", ControllerName = "Home" });
                    obj.Add(new MenuEntity() { MenuName = "Full List", ActionName = "FullList", ControllerName = "Home" });
                    obj.Add(new MenuEntity() { MenuName = "Validation", ActionName = "Validation", ControllerName = "Home" });
                    if (TempData.ContainsKey("MenuList"))
                    {
                        TempData.Remove("MenuList");
                    }
                    TempData.Put("MenuList", obj);
                    HttpContext.Session.SetString("username", "John");
                    return RedirectToAction("Dashboard");
                }
                else if (u.Username.Equals("Jack") && u.Password.Equals("Jack123"))
                {
                    obj = new List<MenuEntity>();
                    ViewData["LoggedInRole"] = "Administrator";
                    obj.Add(new MenuEntity() { MenuName = "Dashboard", ActionName = "AdminDashboard", ControllerName = "Home" });
                    obj.Add(new MenuEntity() { MenuName = "Service List", ActionName = "ServiceList", ControllerName = "Home" });
                    obj.Add(new MenuEntity() { MenuName = "Configuration", ActionName = "ServiceConfiguration", ControllerName = "Home" });
                    if (TempData.ContainsKey("MenuList"))
                    {
                        TempData.Remove("MenuList");
                    }
                    TempData.Put("MenuList", obj);
                    HttpContext.Session.SetString("username", "Jack");
                    return RedirectToAction("AdminDashboard");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login");
        }
    }
}
