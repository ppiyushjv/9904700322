using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOSSWORKLOG.DATA;

namespace MOSSWORKLOG.Models
{
    public class HomeViewModel
    {
        public int PorjectCount { get; set; }
        public int TaskCount { get; set; }
        public int UserCount { get; set; }
        public int ClientCount { get; set; }        
    }

    public class MenuModel
    {
        public List<tblMenu> Menu { get; set; }
    }
}