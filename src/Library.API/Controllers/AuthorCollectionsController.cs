using AutoMapper;
using Library.API.Entities;
using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Library.API.Controllers
{
    [Route("api/authorcollections")]
    public class AuthorCollectionsController : Controller
    {
        private readonly ILibraryRepository libraryRepository;

        public AuthorCollectionsController(ILibraryRepository libraryRepository)
        {
            this.libraryRepository = libraryRepository;
        }

        [HttpPost]
        public IActionResult CreateAuthorCollection([FromBody] IEnumerable<AuthorForCreationDto> authorCollection)
        {
            if (authorCollection == null)
            {
                return BadRequest();
            }

            var authorEntites = Mapper.Map<IEnumerable<Author>>(authorCollection);

            foreach (var author in authorEntites)
            {
                libraryRepository.AddAuthor(author);
            }

            if (!libraryRepository.Save())
            {
                throw new Exception("Creating author collection failed on save.");
            }

            return Ok();
        }


    }
}
