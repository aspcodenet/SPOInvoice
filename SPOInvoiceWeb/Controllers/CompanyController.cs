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

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ViewModels.CompanyEditViewModel());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var entities = new SPOInvoiceEntities())
            {
                var obj = entities.Company.FirstOrDefault(x => x.id == id);
                entities.Company.RemoveRange(new[] { obj  });
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Create(ViewModels.CompanyEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            using (var entities = new SPOInvoiceEntities())
            {
                var model = new Models.Company();

                model.InvoiceAddress = viewModel.InvoiceAddress;
                model.InvoiceDefaultPaymentTermsDays = viewModel.InvoiceDefaultPaymentTermsDays;
                model.InvoiceEmail = viewModel.InvoiceEmail;
                model.InvoiceName = viewModel.InvoiceName;
                model.InvoicePostAddress = viewModel.InvoicePostAddress;
                model.InvoicePostNo = viewModel.InvoicePostNo;
                model.name = viewModel.name;
                model.OrgNo = viewModel.OrgNo;
                model.Founded = viewModel.Founded;

                entities.Company.Add(model);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }

        }



        protected ViewModels.CompanyEditViewModel GetCompanyFromDatabaseAndConvertToViewModel(int id)
        {
            using (var entities = new SPOInvoiceEntities())
            {
                var model = entities.Company.FirstOrDefault(c => c.id == id);
                var viewModel = new ViewModels.CompanyEditViewModel();
                viewModel.id = model.id;
                viewModel.InvoiceAddress = model.InvoiceAddress;
                viewModel.InvoiceDefaultPaymentTermsDays =
                    model.InvoiceDefaultPaymentTermsDays.HasValue ? model.InvoiceDefaultPaymentTermsDays.Value
                    : 30;
                viewModel.InvoiceEmail = model.InvoiceEmail;
                viewModel.InvoiceName = model.InvoiceName;
                viewModel.InvoicePostAddress = model.InvoicePostAddress;
                viewModel.InvoicePostNo = model.InvoicePostNo;
                viewModel.name = model.name;
                viewModel.OrgNo = model.OrgNo;
                viewModel.Founded = model.Founded.HasValue ? model.Founded.Value : DateTime.Now;

                return viewModel;
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = GetCompanyFromDatabaseAndConvertToViewModel(id);
            return View(viewModel);
        }



        [HttpPost]
        public ActionResult Edit(ViewModels.CompanyEditViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            using (var entities = new SPOInvoiceEntities())
            {
                var model = entities.Company.FirstOrDefault(c => c.id == viewModel.id);

                model.InvoiceAddress = viewModel.InvoiceAddress;
                model.InvoiceDefaultPaymentTermsDays = viewModel.InvoiceDefaultPaymentTermsDays;
                model.InvoiceEmail = viewModel.InvoiceEmail;
                model.InvoiceName = viewModel.InvoiceName;
                model.InvoicePostAddress = viewModel.InvoicePostAddress;
                model.InvoicePostNo = viewModel.InvoicePostNo;
                model.name = viewModel.name;
                model.OrgNo = viewModel.OrgNo;
                model.Founded = viewModel.Founded;

                entities.SaveChanges();
                return RedirectToAction("Index");
            }

        }


    }
}