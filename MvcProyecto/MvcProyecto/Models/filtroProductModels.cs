using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProyecto.Models
{
    public class filtroProductModels
    {
        public string SearchText { get; set; }
        public List<Proyecto.DataAccess.product> Product { get; set; }
    }
}