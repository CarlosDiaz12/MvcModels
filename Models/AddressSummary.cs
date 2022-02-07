using MvcModels.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModels.Models
{
    // Applying the Bind Attribute
    // [Bind(Include = "City")]

    // Using the ModelBinder Attribute
    [ModelBinder(typeof(AddressSummaryBinder))]
    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}