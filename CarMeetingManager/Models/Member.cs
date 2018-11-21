using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required][Display(Name="Naam")]
        public string Name { get; set; }
        [Required][Display(Name="Voornaam")]
        public string Surname { get; set; }
        [Required][Display(Name="Geboortedatum")]
        public DateTime DateOfBirth { get; set; }
        [Required][DataType(DataType.PostalCode)][Display(Name="Postcode")]
        public string PostalCode { get; set; }
        [Required][Display(Name="Gemeente")]
        public string City { get; set; }
        [Required][EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        [Required]
        public int CarId { get; set; }
        public int ClubId { get; set; }

        //Navigation properties
        public Car Car { get; set; }
        public Club Club { get; set; }
    }
}
