using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingTour.Server.Data;
using BlazingTour.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingTour.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly BlazingTourContext _context;

        public CitiesController(BlazingTourContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cites = await _context.cities.ToListAsync();
            return Ok(cites);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cities = await _context.cities.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(cities);
        }
        [HttpPost]

        public async Task<IActionResult> Post(City city)
        {
            _context.Add(city);
            await _context.SaveChangesAsync();
            return Ok(city.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(City city)
        {
            _context.Entry(city).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var city = new City { Id = id };
            _context.Remove(city);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
