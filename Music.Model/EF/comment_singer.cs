//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class comment_singer
    {
        public int user_id { get; set; }
        public int singer_id { get; set; }
        public string comment_singer_content { get; set; }
        public System.DateTime comment_singer_createdate { get; set; }
    
        public virtual singer singer { get; set; }
    }
}
