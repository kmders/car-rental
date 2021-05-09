using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class VehicleDetailViewModel
    {
        public VehicleDTO Vehicle { get; set; }
        public List<VehicleImage> VehicleImages { get; set; }
        public List<VehicleRentalPriceDTO> VehicleRentalPrices { get; set; }
    }
}
