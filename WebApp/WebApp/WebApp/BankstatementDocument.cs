//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class BankstatementDocument
    {
        public string PhoneNumber { get; set; }
        public string BankstatementDocumentUrl { get; set; }
        public int BankStatmentId { get; set; }
    
        public virtual Register Register { get; set; }
        public virtual Register Register1 { get; set; }
    }
}
