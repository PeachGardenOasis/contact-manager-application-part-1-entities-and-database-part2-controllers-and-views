using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // data annotations needed for required fields
using System.Linq;
using System.Threading.Tasks;


namespace Lab3Contact_Manager_Application.Models
{
    public class Contact
    {
        public int ContactId { get; set; } // primary key is mandatory so no need to put required
        // priamry ket is auto generated sql
        [Required(ErrorMessage = "Please enter a valid firstname")] // Validation is required
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter a valid lastname")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        public string Organization { get; set; } // optional validation

        public DateTime DateAdded { get; set; } // date added is actually persisting this to datebase
        [Range(1, 10000, ErrorMessage = "Please select a category")]

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Slug => Firstname?.Replace(' ', '-').ToLower() // validation n/a read only
            + "-" + Lastname?.Replace(' ', '-').ToLower();


    }
}

