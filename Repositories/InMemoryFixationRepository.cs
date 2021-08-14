using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrafficControl.Models;

namespace TrafficControl.Repositories
{
    public class InMemoryFixationRepository : IFixationRepository
    {
        private readonly List<CarSpeedFixationItem> fixations = new()
        {
            new CarSpeedFixationItem
            {
                Id = Guid.NewGuid(),
                CarNumber = "1234 PP-7",
                CarSpeed = 65.5f,
                FixationDateTime = new DateTime(2021, 07, 20, 14, 31, 25)
            },
            new CarSpeedFixationItem
            {
                Id = Guid.NewGuid(),
                CarNumber = "4364 PE-7",
                CarSpeed = 68.4f,
                FixationDateTime = new DateTime(2021, 07, 20, 14, 32, 44)
            },
            new CarSpeedFixationItem
            {
                Id = Guid.NewGuid(),
                CarNumber = "1237 OH-7",
                CarSpeed = 75.9f,
                FixationDateTime = new DateTime(2021, 07, 20, 14, 32, 55)
            },
        };

        public async Task AddSpeedFixationAsync(CarSpeedFixationItem fixation)
        {
            fixations.Add(fixation);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<CarSpeedFixationItem>> GetAllFixationsAsync()
        {
            return await Task.FromResult(fixations);
        }

        public async Task<CarSpeedFixationItem> GetSingleFixationAsync(Guid id)
        {
            var fixation = fixations.SingleOrDefault(fixation => fixation.Id == id);
            return await Task.FromResult(fixation);
        }

        public async Task<IEnumerable<CarSpeedFixationItem>> GetFixationsOnDateBySpeedAsync(DateTime datetime, float speed)
        {
            var filteredFixations = fixations.Where(fixation => fixation.FixationDateTime.Date == datetime.Date && fixation.CarSpeed >= speed);
            return await filteredFixations.ToAsyncEnumerable().ToListAsync(); // QUESTION: Maybe its faster to use WhereAwait?
        }

        public async Task<IEnumerable<CarSpeedFixationItem>> GetMinAndMaxSpeedOnDateAsync(DateTime datetime)
        {
            var filteredFixations = fixations.Where(fixation =>
                fixation.FixationDateTime.Date == datetime.Date &&
                fixation.CarSpeed == fixations.Min(fixation => fixation.CarSpeed) &&
                fixation.CarSpeed == fixations.Max(fixation => fixation.CarSpeed)).Distinct();

            return await filteredFixations.ToAsyncEnumerable().ToListAsync();
        }
    }
}