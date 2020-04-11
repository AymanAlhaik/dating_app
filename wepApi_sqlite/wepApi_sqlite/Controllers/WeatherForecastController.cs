using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using wepApi_sqlite.Models;

namespace wepApi_sqlite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly TodoContext _context;
        public WeatherForecastController(TodoContext options)
        {
            this._context = options;

        }

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.TodoItems.ToListAsync();
            return Ok(values);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.TodoItems.FirstOrDefaultAsync(todo => todo.Id == id);
            return Ok(value);
        }
    }
}
