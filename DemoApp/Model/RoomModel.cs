using System.ComponentModel.DataAnnotations;

namespace DemoApp.Model
{
    public class RoomModel
    {
        [Key]
        public string RoomID {  get; set; } 
        public string RoomCategory { get; set; }
        public int RoomCapacity { get; set; }
        public decimal RoomPrice { get; set; }

    }
}
