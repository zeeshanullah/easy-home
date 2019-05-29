using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyHome2.Models;

namespace EasyHome2.ViewModels
{
    public class PlotViewModel
    {
        public List<PlotTypes> PlotTypes { get; set; }

        public AdPlotProperty AdPlotProperty { get; set; }
    }
}