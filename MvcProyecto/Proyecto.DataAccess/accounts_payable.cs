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
    
    public partial class accounts_payable
    {
        public int accountsPayable_code { get; set; }
        public int purchase_code { get; set; }
        public int pay_supplier { get; set; }
        public Nullable<double> was_paid { get; set; }
        public Nullable<double> outstanding_balance { get; set; }
        public string credit_time { get; set; }
        public Nullable<System.DateTime> present_date { get; set; }
        public string sstate { get; set; }
        public Nullable<System.DateTime> pay_date { get; set; }
        public string made_by { get; set; }
        public Nullable<System.DateTime> date_cancellation { get; set; }
    
        public virtual bills bills { get; set; }
        public virtual suppliers suppliers { get; set; }
    }
}
