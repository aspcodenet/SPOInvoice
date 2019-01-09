using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPOInvoiceWeb.ViewModels
{
    public class CompanyEditViewModel
    {
        public int id { get; set; }

        [StringLength(15)]
        public string OrgNo { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string InvoiceName { get; set; }

        [StringLength(255)]
        public string InvoiceAddress { get; set; }

        [StringLength(255)]
        public string InvoicePostNo { get; set; }

        [Required]
        public string InvoicePostAddress { get; set; }

        [EmailAddress]
        [Required]
        public string InvoiceEmail { get; set; }

        public int InvoiceDefaultPaymentTermsDays { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime Founded { get; set; }
        public bool StorKund { get; set; }

    }
}