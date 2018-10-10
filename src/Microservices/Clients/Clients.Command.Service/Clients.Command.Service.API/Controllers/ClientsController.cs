using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clients.Command.Service.Domain.AggregatesModel.ClientAggregate;
using Clients.Command.Service.Infrastructure;
using Services.Common.DomainObjects.Interfaces;

namespace Clients.Command.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        public ClientsController(IClientRepository repo)
        {
            _repo = repo;
            _unitOfWork = _repo.UnitOfWork;
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient([FromRoute] int id, [FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }

            _repo.Update(client);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var exist = await ClientExists(id);
                if (!exist)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(client);
            await _unitOfWork.SaveChangesAsync();

            return Ok(client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _repo.GetAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _repo.Delete(client);
            await _unitOfWork.SaveChangesAsync();

            return Ok(client);
        }

        private async Task<bool> ClientExists(int id)
        {
            return await _repo.AnyAsync(id);
        }
    }
}