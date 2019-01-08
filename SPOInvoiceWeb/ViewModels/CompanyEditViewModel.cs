using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPOInvoiceWeb.ViewModels
{
    public class CompanyEditViewModel
    {
        public int id { get; set; }
        public string OrgNo { get; set; }
        public string name { get; set; }
        public string InvoiceName { get; set; }
        public string InvoiceAddress { get; set; }
        public string InvoicePostNo { get; set; }
        public string InvoicePostAddress { get; set; }
        public string InvoiceEmail { get; set; }
        public int InvoiceDefaultPaymentTermsDays { get; set; }
        public System.DateTime Founded { get; set; }
        public bool StorKund { get; set; }

    }
}