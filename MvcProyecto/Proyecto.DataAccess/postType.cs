//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class postType
    {
        public postType()
        {
            this.EMPLOYEE = new HashSet<EMPLOYEE>();
        }
    
        public int id { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<EMPLOYEE> EMPLOYEE { get; set; }
    }
}
