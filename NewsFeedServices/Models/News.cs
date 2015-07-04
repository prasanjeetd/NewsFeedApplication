//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewsFeedServices.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class News
    {
        public long NewsId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Title { get; set; }
        public string Descripion { get; set; }
        public Nullable<int> CreatedById { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public bool IsPublished { get; set; }
        public Nullable<System.DateTime> PublishedDate { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
