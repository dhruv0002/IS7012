using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class Dwelling
    {
        public int DwellingId { get; set; }

        [DisplayName("Dwelling Name")]
        [Required(ErrorMessage = "Dwelling name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid dwelling name")]
        public string DwellingName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Listing Time")]
        [Required(ErrorMessage = "Listing time is required")]
        public DateTime ListingTime { get; set; }

        [DisplayName("For Sale")]
        public bool IsForSale { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Enter valid cost")]
        public decimal Cost { get; set; }

        [DisplayName("Agent")]
        public Agent AgentAssoc { get; set; }

        [DisplayName("Agent Associated")]
        public int AgentAssocId { get; set; }

        [DisplayName("City")]
        public City CityAssoc { get; set; }

        [DisplayName("City Associated")]
        public int CityAssocId { get; set; }

    }
}
