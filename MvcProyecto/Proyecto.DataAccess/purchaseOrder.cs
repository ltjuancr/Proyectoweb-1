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
    
    public partial class purchaseOrder
    {
        public purchaseOrder()
        {
            this.accounts_payable = new HashSet<accounts_payable>();
            this.detailPurchaseOrder = new HashSet<detailPurchaseOrder>();
        }
    
        public int id { get; set; }
        public int supplier { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public Nullable<int> amount_total { get; set; }
        public Nullable<int> total_taxes { get; set; }
        public Nullable<int> total_withTaxes { get; set; }
        public string state { get; set; }
    
        public virtual ICollection<accounts_payable> accounts_payable { get; set; }
        public virtual ICollection<detailPurchaseOrder> detailPurchaseOrder { get; set; }
        public virtual supplier supplier1 { get; set; }
    }
}
