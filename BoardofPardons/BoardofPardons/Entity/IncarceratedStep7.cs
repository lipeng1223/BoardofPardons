
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace BoardofPardons.Entity
{

using System;
    using System.Collections.Generic;
    
public partial class IncarceratedStep7
{

    public int Id { get; set; }

    public int FormId { get; set; }

    public string sign1 { get; set; }

    public System.DateTime date1 { get; set; }

    public System.DateTime date2 { get; set; }

    public string sign2 { get; set; }

    public Nullable<System.DateTime> CreatedAt { get; set; }

    public Nullable<System.DateTime> UpdatedAt { get; set; }



    public virtual Form Form { get; set; }

}

}