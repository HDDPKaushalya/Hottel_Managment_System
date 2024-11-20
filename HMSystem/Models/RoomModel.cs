using System.ComponentModel.DataAnnotations;

namespace HMSystem.Models
{
    public class RoomModel
    {
        [Display(Name ="Room ID")]
        [Required(ErrorMessage ="Need to add Room ID")]
        public string RoomID { get; set; }
        [Display(Name ="Room Category")]
        [Required(ErrorMessage ="Need to add Room Category")]
        public string RoomCategory { get; set; }
        [Display(Name ="Room Capacity")]
        [Required(ErrorMessage = "Need to add Room Capacity")]
        public int RoomCapacity { get; set; }
        [Display(Name = "Room Price")]
        [Required(ErrorMessage = "Need to add Room Price")]
        public decimal RoomPrice { get; set; }
    }
}
