using System;

namespace TrafficControl.DTOs
{
    public class FixationItemDto
    {
        public Guid Id { get; set; }
        public DateTime FixationDateTime { get; set; }
        public string CarNumber { get; set; }
        public float CarSpeed { get; set; }
    }
}