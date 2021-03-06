using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseProject.Models.House
{
    public class HouseListViewModel
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
