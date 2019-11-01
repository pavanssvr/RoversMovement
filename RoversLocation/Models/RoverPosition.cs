using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class RoverPosition
    {
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Plateau { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Position { get; set; }

        [Required]
        public string MovementSignals { get; set; }        
    }
}
