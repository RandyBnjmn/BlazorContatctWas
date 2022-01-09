using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorContactWas.Shared
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is obligatory")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is obligatory")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is obligatory")]

        public string Phone { get; set; }
        [Required (ErrorMessage ="This field is obligatory")]
        public string Address { get; set; }
        //public string FullName { get{
        //        return LastName + ", " + FirstName;
        //    } }
    }
}
