using SPOInvoiceWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPOInvoiceWeb.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            var viewModel = new ViewModels.CompanyListViewModel();
            using (var entities = new SPOInvoiceEntities())
            {
                foreach(var dbCompany in entities.Company)
                {
                    viewModel.Companies.Add( new ViewModels.CompanyListViewModel.CompanyViewModel
                    {
                        Id = dbCompany.id,
                        Name = dbCompany.name,
                        OrgNo = dbCompany.OrgNo
                    }
                        );
                }
            }
            return View(viewModel);
        }
    }
}