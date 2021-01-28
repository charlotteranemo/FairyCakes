using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FairyCakes.Models
{
    public class OrderModel
    {
        
        [Required(ErrorMessage = "You need to fill out your name!")]
        [MinLength(2)]
        [Display(Name = "Your name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "You need to enter a phone number.")]
        [MaxLength(11, ErrorMessage = "Number cannot be more than 11 numbers long!")]
        [MinLength(9, ErrorMessage = "Number cannot be less than 9 numbers long!")]
        [Phone(ErrorMessage = "You need to enter a valid phone number!")]
        public string Phone { get; set; }
        public List<SelectListItem> Cakes { get; } = new List<SelectListItem>
            {
                new SelectListItem { Text = "Fruit cake", Value = "fruitCake" },
                new SelectListItem { Text = "Chocolate cake", Value = "chocolateCake" },
                new SelectListItem { Text = "Vanilla cake", Value = "vanillaCake" },
                new SelectListItem { Text = "Red velvet cake", Value = "redVelvetCake" },
                new SelectListItem { Text = "Valentine cake", Value = "valentineCake" }
            };
        public string Cake { get; set; }
        public List<SelectListItem> Slices { get; } = new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = "6",
                Text = "6 slices (£20)"
            },
            new SelectListItem
            {
                Value = "8",
                Text = "8 slices (£28)"
            },
            new SelectListItem
            {
                Value = "10",
                Text = "10 slices (£35)"
            }
        };
        [Required(ErrorMessage = "You need to choose the size of your cake!")]
        public string Slice { get; set; }
        [Display(Name = "Yes, add a custom message (£5)")]
        public bool Customisation { get; set; }
        [Display(Name = "Custom message")]
        public string CustomisationString { get; set; }
        [Required(ErrorMessage = "You need to choose the pickup date")]
        [DataType(DataType.Date)]
        [Display(Name = "Day of pickup")]
        public DateTime PickupDay { get; set; }
        public int TotalPrice { get; set; }
        public object ViewBag { get; }
    }
}
