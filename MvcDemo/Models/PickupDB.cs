using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcDemo.Models
{
    public class PickupDB : IValidatableObject
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "*First name is required")]
        [Display(Name="First Name")]
        public string firstn { get; set; }

        [Required(ErrorMessage = "*Last name is required")]
        [Display(Name = "Last Name")]
        public string lastn { get; set; }

        [Required(ErrorMessage = "*Contact number is required")]
        [Display(Name = "Contact Number")]
        public Int64 number { get; set; }

        [Display(Name = "Email address(optional)")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "*Pickup address is required")]
        [Display(Name = "Pick up Address")]
        [DataType(DataType.MultilineText)]
        public string address { get; set; }

        [Required(ErrorMessage = "*Postal code is required")]
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public int pincode { get; set; }

        [Required(ErrorMessage = "*Date of pickup is required")]
        [Display(Name = "Date")]
        public string date { get; set; }

        [Required(ErrorMessage = "*Pickup Time is required")]
        [Display(Name = "Time")]
        public string time { get; set; }

        [Required(ErrorMessage = "*Approx. Weight of parcel is required")]
        [Display(Name = "Approx. Weight")]
        public int weight { get; set; }

        [Display(Name = "Your Experience")]
        [DataType(DataType.MultilineText)]
        public string complaint { get; set; }
        
      
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!((number>10000000 && number<100000000) || (number >1000000000 && number <10000000000)))
            {
                yield return new ValidationResult("Please go back and enter correct phone number");
            }

            if (!(pincode/10000).Equals(56))
            {
                yield return new ValidationResult("Please go back and enter correct pincode.");
            }

            if (weight > 20)
            {
                yield return new ValidationResult("Packages of weight over 20Kg are not allowed.");
            }
        }
    }


    public class PickupDBContext : DbContext
    {
        public DbSet<PickupDB> Pickup { get; set; }
    }

}