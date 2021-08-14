using System;

namespace TrafficControl.Models
{
    public class CarSpeedFixationItem
    {
        public Guid Id { get; set; }
        public DateTime FixationDateTime { get; set; }
        public string CarNumber { get; set; }
        public float CarSpeed { get; set; }
    }
}