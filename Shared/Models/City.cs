using System;
using System.Collections.Generic;
using System.Text;

namespace BlazingTour.Shared.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime EventDate { get; set; }
    }
}
