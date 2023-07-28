using FoodProject.Data.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;

namespace FoodProject.Data
{
    public class AramaModel
    {
        public string AramaKey { get; set; }
        public List<Food> Foods { get; set; }
        public List<About> Abouts { get; set; }
    }
}
