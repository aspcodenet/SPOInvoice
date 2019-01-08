using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPOInvoiceWeb.ViewModels
{
    public class CompanyListViewModel
    {
        public CompanyListViewModel()
        {
            Companies = new List<CompanyViewModel>();
        }
        public class CompanyViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string OrgNo { get; set; }
        }
        public List<CompanyViewModel> Companies { get; set; }
    }
}