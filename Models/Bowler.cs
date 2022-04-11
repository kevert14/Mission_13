using System;
using System.ComponentModel.DataAnnotations;

namespace Mission_13.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }

       [Required(ErrorMessage = "Please enter the last name")]
        public string BowlerLastName { get; set; }

        [Required(ErrorMessage = "Please enter the first name")]
        public string BowlerFirstName { get; set; }

        [Required(ErrorMessage = "Please enter the middle initial")]
        public string BowlerMiddleInit { get; set; }

        [Required(ErrorMessage = "Please enter the address")]
        public string BowlerAddress { get; set; }

        [Required(ErrorMessage = "Please enter the city")]
        public string BowlerCity { get; set; }

        [Required(ErrorMessage = "Please enter the state")]
        public string BowlerState { get; set; }

        [Required(ErrorMessage = "Please enter the zipcode")]
        public string BowlerZip { get; set; }

        [Required(ErrorMessage = "Please enter the phone number")]
        public string BowlerPhoneNumber { get; set; }
        public int TeamID { get; set; }


    }
}