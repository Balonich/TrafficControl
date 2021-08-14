using TrafficControl.DTOs;
using TrafficControl.Models;

namespace TrafficControl.Helpers
{
    public static class Extentions
    {
        public static FixationItemDto AsDto(this CarSpeedFixationItem fixation)
        {
            return new FixationItemDto
            {
                Id = fixation.Id,
                CarNumber = fixation.CarNumber,
                CarSpeed = fixation.CarSpeed,
                FixationDateTime = fixation.FixationDateTime
            };
        }
    }
}