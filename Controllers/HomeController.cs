using MvcModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private Person[] personData = {
            new Person {PersonId = 1, FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person {PersonId = 2, FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person {PersonId = 3, FirstName = "John", LastName = "Smith", Role = Role.User},
            new Person {PersonId = 4, FirstName = "Anne", LastName ="Jones",Role = Role.Guest}
        };

        // public ActionResult Index(int id = 1) -- OPTIONAL PARAMETER
        public ActionResult Index(int? id)
        {
            Person dataItem = personData.Where(p => p.PersonId == id).First();
            return View(dataItem);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }
        [HttpPost]
        public ActionResult CreatePerson(Person model)
        {
            return View("Index", model);
        }
        // Applying the Bind Attribute
        public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress", Exclude = "Country")]AddressSummary summary)
        {
            return View(summary);
        }

        public ActionResult Names(IList<string> names)
        {
            names = names ?? new List<string>();
            return View(names);
        }
        public ActionResult Address()
        {
            // Manually Invoking the Model Binding Process
            IList<AddressSummary> addresses = new List<AddressSummary>();
            UpdateModel(addresses);
            return View(addresses);
        }

        /*
         OPTIONAL: 1

        try {
        UpdateModel(addresses, formData);
        } catch (InvalidOperationException ex) {
        // provide feedback to user
        }

        OPTIONAL 2
        IList<AddressSummary> addresses = new List<AddressSummary>();
        if (TryUpdateModel(addresses, formData)) {
        // proceed as normal
        } else {
        // provide feedback to user
        }

        OPTIONAL: 3
        public ActionResult Address(FormCollection formData) {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            UpdateModel(addresses, formData);
            return View(addresses);
        }
         */
    }
}