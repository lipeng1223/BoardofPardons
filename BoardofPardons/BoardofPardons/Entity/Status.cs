using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardofPardons.Entity
{
    public class FormStatus
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}
