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
    
    public partial class detailPurchaseOrder
    {
        public int id { get; set; }
        public int product { get; set; }
        public Nullable<int> amount { get; set; }
        public Nullable<int> price { get; set; }
        public int purchaseOrder { get; set; }
    
        public virtual product product1 { get; set; }
        public virtual purchaseOrder purchaseOrder1 { get; set; }
    }
}
