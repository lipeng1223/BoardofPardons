using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardofPardons.Entity
{
    public class AllUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string Role { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    }
}
