using Hotel.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Data.DTO
{
    public class HomePageMediaDTO
    {
        public HomePage? HomePage { get; set; }
        public Media? Banner { get; set; }
        public Media? Grafika { get; set; }
    }
}
