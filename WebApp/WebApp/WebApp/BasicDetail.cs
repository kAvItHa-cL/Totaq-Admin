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
    
    public partial class BasicDetail
    {
        public int BasicDetailsId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string PANCard { get; set; }
        public string AdharCard { get; set; }
        public string KYCStatus { get; set; }
    
        public virtual Register Register { get; set; }
        public virtual Register Register1 { get; set; }
    }
}
