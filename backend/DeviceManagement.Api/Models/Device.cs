namespace DeviceManagement.Api.Models
{
    public class Device
    {
        public int DeviceID {  get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string OperatingSystem { get; set; }
        public string OSVersion { get; set; }
        public string Processor { get; set; }
        public int RAMAmount { get; set; }
        public string? Description { get; set; }

        public ICollection<DeviceAssignment> Assignments { get; set; }
    }
}
