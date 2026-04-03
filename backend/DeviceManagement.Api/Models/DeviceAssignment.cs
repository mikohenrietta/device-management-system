namespace DeviceManagement.Api.Models
{
    public class DeviceAssignment
    {
        public int DeviceAssignmentID { get; set; }
        public int UserID { get; set; }
        public int DeviceID { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime? UnassignedAt { get; set; }
    }
}
