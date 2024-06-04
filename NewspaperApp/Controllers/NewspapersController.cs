using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewspaperApp15003.Data;
using NewspaperApp15003.Models;
using NewspaperApp15003.Repositories;

namespace NewspaperApp15003.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewspapersController : ControllerBase
    {
        private readonly NewspaperDbContext _context;
        private readonly INewspapersRepository _newspapersRepository;

        public NewspapersController(INewspapersRepository newspapersRepository)
        {
            _newspapersRepository = newspapersRepository;
        }

        // GET: api/Newspapers
        [HttpGet]
        public async Task<IEnumerable<Newspaper>> GetNewspapers()
        {
            return await _newspapersRepository.GetAllNewspapers();
        }

        // GET: api/Newspapers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Newspaper>> GetNewspaper(int id)
        {
            var newspaper = await _newspapersRepository.GetSingleNewspaper(id);

            if (newspaper == null)
            {
                return NotFound();
            }

            return Ok(newspaper);
        }

        // PUT: api/Newspapers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewspaper(int id, Newspaper newspaper)
        {
            if (id != newspaper.Id)
            {
                return BadRequest();
            }

            await _newspapersRepository.UpdateNewspaper(newspaper);
            return NoContent();
        }

        // POST: api/Newspapers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Newspaper>> PostNewspaper(Newspaper newspaper)
        {
            await _newspapersRepository.CreateNewspaper(newspaper);

            return CreatedAtAction("GetNewspaper", new { id = newspaper.Id }, newspaper);
        }

        // DELETE: api/Newspapers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewspaper(int id)
        {
            await _newspapersRepository.DeleteNewspaper(id);

            return NoContent();
        }

        private bool NewspaperExists(int id)
        {
            return (_context.Newspapers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
