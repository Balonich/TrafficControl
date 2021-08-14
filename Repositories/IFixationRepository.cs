using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrafficControl.Models;

namespace TrafficControl.Repositories
{
    public interface IFixationRepository
    {
        Task AddSpeedFixationAsync(CarSpeedFixationItem item);
        Task<IEnumerable<CarSpeedFixationItem>> GetAllFixationsAsync();
        Task<IEnumerable<CarSpeedFixationItem>> GetFixationsOnDateBySpeedAsync(DateTime datetime, float speed);
        Task<IEnumerable<CarSpeedFixationItem>> GetMinAndMaxSpeedOnDateAsync(DateTime datetime);
    }
}