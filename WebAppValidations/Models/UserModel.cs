using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppValidations.Attributes;

namespace WebAppValidations.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Enter Valid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Valid Passoword")]
        public string Passoword { get; set; }

        [Required(ErrorMessage = "Enter Valid ConfirmPassowrd")]
        [Compare("Passoword", ErrorMessage = "Confirm password does not match!")]
        public string ConfirmPassoword { get; set; }

        [RegularExpression("^[6,7,8,9]\\d{9}$",ErrorMessage = "Enter Valid MobileNo")]
        public string MobileNo { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Valid Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Enter Valid City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        public Gender UserGender { get; set; }

        [TermsValidation(ErrorMessage ="Please check the terms")]
        public bool Terms { get; set; }

        public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = " ", Text = " "},
            new SelectListItem { Value = "IN", Text = "India" },
            new SelectListItem { Value = "CA", Text = "Canada" },
            new SelectListItem { Value = "US", Text = "USA"  },
        };

        public List<SelectListItem> Cities { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = " ", Text = " "},
            new SelectListItem { Value = "MM", Text = "Mumbai" },
            new SelectListItem { Value = "DL", Text = "Delhi" },
            new SelectListItem { Value = "BG", Text = "Banglore"  },
            new SelectListItem { Value = "CH", Text = "Chennai"  },
        };

        //public List<CityModel> Cities { get; } = new List<CityModel>
        //{
        //    new CityModel() { CityId = 1, CityName = "Mumbai", CountryId = 1, CountryName = "India" },

        //    new CityModel() { CityId = 1, CityName = "Mumbai", CountryId = 1, CountryName = "India" },
        //    new CityModel() { CityId = 11, CityName = "Delhi", CountryId = 1, CountryName = "India" },
        //    new CityModel() { CityId = 21, CityName = "Banglore", CountryId = 1, CountryName = "India" },
        //    new CityModel() { CityId = 31, CityName = "Chennai", CountryId = 1, CountryName = "India" },

        //    new CityModel() { CityId = 1, CityName = "NewYork", CountryId = 2, CountryName = "Usa" },
        //    new CityModel() { CityId = 11, CityName = "Tampa", CountryId = 2, CountryName = "Usa" },
        //    new CityModel() { CityId = 21, CityName = "California", CountryId = 2, CountryName = "Usa" },
        //    new CityModel() { CityId = 31, CityName = "Dallas", CountryId = 2, CountryName = "Usa" },

        //    new CityModel() { CityId = 1, CityName = "Toronta", CountryId = 2, CountryName = "Canada" },
        //    new CityModel() { CityId = 11, CityName = "Ottawa", CountryId = 2, CountryName = "Canada" },
        //    new CityModel() { CityId = 21, CityName = "Vancover", CountryId = 2, CountryName = "Canada" },
        //    new CityModel() { CityId = 31, CityName = "Montreal", CountryId = 2, CountryName = "Canada" }
        //};
        //public List<CityModel> CityList { get; set; }

    }

    public enum Gender
        {
            Male,
            Female            
        }
}
