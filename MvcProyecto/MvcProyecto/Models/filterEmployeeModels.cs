using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProyecto.Models
{
        public class filterEmployeeModels
        {
            public string SearchText { get; set; }
            public List<Proyecto.DataAccess.EMPLOYEE> employee { get; set; }
        }
}