using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class City
    {
        public int CityId { get; set; }

        [DisplayName("City Name")]
        [Required(ErrorMessage = "City name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid city name")]
        public string CityName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Enter valid population")]
        public long Population { get; set; }

        public List<Dwelling> Dwellings { get; set; }

    }
}
