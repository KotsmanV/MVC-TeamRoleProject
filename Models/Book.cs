using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamRoleProject.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        //Navigation properties
        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}