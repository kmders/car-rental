using System;

namespace Domain.DTOs
{
    public class VehicleRentalPriceFilter
    {
        public VehicleRentalPriceFilter(int vehicleId, DateTime? date = null)
        {
            VehicleId = vehicleId;
            Date = date;
        }
        public int VehicleId { get; set; }
        public DateTime? Date { get; set; }
    }
}
