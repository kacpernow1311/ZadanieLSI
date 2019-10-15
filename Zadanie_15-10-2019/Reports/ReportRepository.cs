using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanie_15_10_2019.Helpers;
using Zadanie_15_10_2019.Models;
using Zadanie_15_10_2019.Reports.Entities;

namespace Zadanie_15_10_2019.Reports
{
    public class ReportRepository : RepositoryBase<ReportRepository>
    {
        public List<ReportModel> LoadReports()
        {
            var result = new List<ReportModel>();
            try
            {
                using (ReportEntities context = new ReportEntities())
                {
                    result = context.Reports.Select(x => new ReportModel
                    {
                        ID = x.Id,
                        ExportName = x.ExportName,
                        ExportTime = x.ExportTime,
                        UserName = x.UserName,
                        LocalName = x.LocalName
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}