using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BlogPostApp.AppCode
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual void EditProfile()
        {

        }

    }
}
