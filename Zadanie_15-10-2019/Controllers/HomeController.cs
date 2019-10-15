using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zadanie_15_10_2019.Models;
using Zadanie_15_10_2019.Reports;

namespace Zadanie_15_10_2019.Controllers
{
    public class HomeController : BaseController
    {
        #region Properties

        /// <summary>
        /// Gets or sets the data items.
        /// </summary>
        /// <value>
        /// The data items.
        /// </value>
        protected List<ReportModel> DataItems
        {
            get { return TempData.Peek($"{ControllerName}.DataItems") as List<ReportModel>; }
            set
            {
                if (value == null)
                {
                    TempData.Remove($"{ControllerName}.DataItems");
                }
                else
                {
                    TempData[$"{ControllerName}.DataItems"] = value;
                }
            }
        }

        #endregion

        // GET: Home
        public ActionResult Index()
        {
            LoadReports();
            LoadViewBag();
            return View(DataItems);
        }

        public ActionResult ReportGridView()
        {
            return View(DataItems);
        }

        public ActionResult GridViewReload(string localName, string from, string to)
        {
            var filteredList = DataItems;
            if (!String.IsNullOrEmpty(localName))
            {
                filteredList = filteredList.Where(x => x.LocalName == localName).ToList();
            }
            if (!String.IsNullOrEmpty(from))
            {
                DateTime fromDate = DateTime.ParseExact(from, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                filteredList = filteredList.Where(x => x.ExportTime >= fromDate).ToList();
            }
            if (!String.IsNullOrEmpty(to))
            {
                DateTime toDate = DateTime.ParseExact(to, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                filteredList = filteredList.Where(x => x.ExportTime <= toDate).ToList();
            }
            return PartialView("ReportGridView", filteredList);
        }

        private void LoadReports()
        {
            DataItems = ReportRepository.Instance.LoadReports().OrderBy(x=>x.ExportTime).ToList();
        }

        private void LoadViewBag()
        {
            ViewBag.Locals = DataItems.Select(x => x.LocalName).ToList();
        }

    }
}