namespace Domain.DTOs
{
    public class VehicleRentalPriceFilter
    {
        public VehicleRentalPriceFilter(int vehicleId)
        {
            VehicleId = vehicleId;
        }
        public int VehicleId { get; set; }
    }
}
