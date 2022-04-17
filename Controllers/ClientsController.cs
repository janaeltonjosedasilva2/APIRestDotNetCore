using api_rest.Models;
using api_rest.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/clients")]
        [Authorize(Roles = "editor, administrator")]
        public List<Client> Index()
        {
            return _context.Clients.ToList();
        }

        [HttpPost]
        [Route("/clients")]
        [Authorize(Roles = "administrator")]
        public IActionResult Create([FromBody] Client client)
        {
            client.RegisterDate = DateTime.Now;

            _context.Clients.Add(client);
            _context.SaveChanges();

            return StatusCode(201, client);
        }

        [HttpPut]
        [Route("/clients/{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult Update([FromRoute] int id, [FromBody] Client client)
        {
            if (!_context.Clients.Any(c => c.Id == id))
                return StatusCode(404, new { Message = "Client not found." });

            client.RegisterDate = DateTime.Now;
            client.Id = id;
            _context.Clients.Update(client);
            _context.SaveChanges();

            return StatusCode(200, client);
        }

        [HttpDelete]
        [Route("/clients/{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult Delete([FromRoute] int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
                return StatusCode(404, new { Message = "Client not found." });
            
            _context.Clients.Remove(client);
            _context.SaveChanges();

            return StatusCode(204);
        }
    }
}
