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
    
    public partial class requisition
    {
        public requisition()
        {
            this.detailRequisition = new HashSet<detailRequisition>();
            this.route = new HashSet<route>();
        }
    
        public int id { get; set; }
        public int client { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        public string date { get; set; }
        public Nullable<int> amount_total { get; set; }
        public Nullable<int> total_taxes { get; set; }
        public Nullable<int> total_withTaxes { get; set; }
        public Nullable<int> EMPLOYEE { get; set; }
    
        public virtual client client1 { get; set; }
        public virtual ICollection<detailRequisition> detailRequisition { get; set; }
        public virtual EMPLOYEE EMPLOYEE1 { get; set; }
        public virtual ICollection<route> route { get; set; }
    }
}
