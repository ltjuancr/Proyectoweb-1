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
    
    public partial class product
    {
        public product()
        {
            this.detailBill = new HashSet<detailBill>();
            this.detailPurchaseOrder = new HashSet<detailPurchaseOrder>();
            this.detailRequisition = new HashSet<detailRequisition>();
        }

    
        public int id { get; set; }
        public int code { get; set; }
        public int familyProduct { get; set; }
        public string product_name { get; set; }
        public Nullable<double> unit_price { get; set; }
        public Nullable<System.DateTime> expiration { get; set; }
        public Nullable<double> existence { get; set; }
        public int minimum { get; set; }
        public int supplier { get; set; }
    
        public virtual ICollection<detailBill> detailBill { get; set; }
        public virtual ICollection<detailPurchaseOrder> detailPurchaseOrder { get; set; }
        public virtual ICollection<detailRequisition> detailRequisition { get; set; }
        public virtual family_product family_product { get; set; }
        public virtual supplier supplier1 { get; set; }
    }
}
