//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shopping_Cart.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class productimage
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public Nullable<int> ProductId { get; set; }
    
        public virtual product product { get; set; }
    }
}