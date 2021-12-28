using System;
using System.Collections.Generic;
using System.Linq;
using BookManagementApi.Data;
using BookManagementApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BooksManagementController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksManagementController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllBooks")]
        public ActionResult<List<BookItems>> GetBooks()
        {
            var items = _context.BookItems.ToList();
            return Ok(items);
        }

        [HttpGet("GetBookById/{id}")]
        public ActionResult GetBookById(int id)
        {
            if(id <= 0)
            {
                NotFound();
            }
            var items = _context.BookItems.FirstOrDefault(x => x.Id == id);

            return Ok(items);
        }

        [HttpGet("GetBookByAuthor/{author}")]
        public ActionResult GetBookByAuthor(string author)
        {
            var items = _context.BookItems.FirstOrDefault(x => x.Author == author);
            if(items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }


        [HttpPost]
        public ActionResult AddBooks([FromBody] BookItems model)
        {
            if(model == null)
            {
                return BadRequest();
            }
            _context.BookItems.Add(model);
            _context.SaveChanges();

            return CreatedAtAction("AddBooks", model);
        }

        [HttpPut]
        public ActionResult UpdateBook([FromQuery] int idNumber, [FromBody] BookItems model)
        {
            if(idNumber <= 0)
            {
                return NotFound();
            }

            var item = _context.BookItems.FirstOrDefault(x => x.Id == idNumber);

            if(item == null)
            {
                return BadRequest();
            }

            item.Name = model.Name;
            item.Description = model.Description;
            item.Author = model.Author;
            model.DateAdded = DateTime.Now;
            item.DateAdded = model.DateAdded;

            _context.BookItems.Update(item);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("DeleteBookById/{id}")]
        public ActionResult DeleteBook(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var item = _context.BookItems.FirstOrDefault(x => x.Id == id);
            _context.BookItems.Remove(item);

            return NoContent();
        }


    }
}