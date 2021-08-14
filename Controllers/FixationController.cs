using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrafficControl.DTOs;
using TrafficControl.Helpers;
using TrafficControl.Models;
using TrafficControl.Repositories;

namespace TrafficControl.Controllers
{
    [ApiController]
    [Route("fixations")]
    public class FixationController : ControllerBase
    {
        private readonly IFixationRepository repository;

        public FixationController(IFixationRepository repository)
        {
            this.repository = repository;
        }

        // GET /fixations
        [HttpGet]
        public async Task<IEnumerable<FixationItemDto>> GetFixationsAsync()
        {
            var fixations = (await repository.GetAllFixationsAsync())
                        .Select(fixation => fixation.AsDto());
            return fixations;
        }

        // GET /fixations/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FixationItemDto>> GetFixationAsync(Guid id)
        {
            var fixation = await repository.GetSingleFixationAsync(id);

            if (fixation is null)
            {
                return NotFound();
            }

            return fixation.AsDto();
        }

        // POST /fixations
        [HttpPost]
        public async Task<ActionResult<FixationItemDto>> CreateItemAsync(CreateFixationItemDto fixationDto)
        {
            CarSpeedFixationItem fixation = new()
            {
                Id = Guid.NewGuid(),
                CarNumber = fixationDto.CarNumber,
                CarSpeed = fixationDto.CarSpeed,
                FixationDateTime = fixationDto.FixationDateTime
            };

            await repository.AddSpeedFixationAsync(fixation);

            return CreatedAtAction(nameof(GetFixationAsync), new { id = fixation.Id }, fixation.AsDto());
        }
    }
}