using System;

namespace TrafficControl.DTOs
{
    public class CreateFixationItemDto
    {
        public DateTime FixationDateTime { get; set; }
        public string CarNumber { get; set; }
        public float CarSpeed { get; set; }
    }
}