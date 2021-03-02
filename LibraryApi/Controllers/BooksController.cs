using LibraryApi.Models.Books;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class BooksController : ControllerBase
    {

        [HttpGet("/books/{id:int}")] 
        public async Task<ActionResult> GetBookById(int id)
        {
            var response = new GetBookDetailsResponse
            {
                Id = id,
                Title = "Some Title",
                Author = "Some Author",
                Genre = "Fiction"
            };
            return Ok(response);
        }
    }
}
