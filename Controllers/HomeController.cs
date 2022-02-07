﻿using MvcModels.Models;
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

        public ActionResult Names(string[] names)
        {
            names = names ?? new string[0];
            return View(names);
        }
    }
}