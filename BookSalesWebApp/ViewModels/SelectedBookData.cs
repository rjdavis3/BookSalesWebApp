using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSalesWebApp.ViewModels
{
    public class SelectedBookData
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public bool Selected { get; set; }
    }
}
