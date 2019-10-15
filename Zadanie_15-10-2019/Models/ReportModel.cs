using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Zadanie_15_10_2019.Models
{
    public class ReportModel
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("Nazwa eksportu")]
        public string ExportName { get; set; }

        [DisplayName("Data eksportu")]
        public DateTime? ExportTime { get; set; }

        [DisplayName("Nazwa użytkownika")]
        public string UserName { get; set; }

        [DisplayName("Nazwa lokalu")]
        public string LocalName { get; set; }
    }
}