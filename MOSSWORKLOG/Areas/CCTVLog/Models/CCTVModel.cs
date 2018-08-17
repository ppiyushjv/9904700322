using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOSSWORKLOG.Areas.CCTVLog.Models
{
    public class CCTVModel
    {
        public bool IsEdit { get; set; }
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public string CCTVNo { get; set; }
        public string Duration { get; set; }
    }

    public class CCTVViewModel
    {
        public IList<CCTVModel> CCTVLogs { get; set; }

        public CCTVViewModel()
        {
            this.CCTVLogs = new List<CCTVModel>();
        }
    }
}