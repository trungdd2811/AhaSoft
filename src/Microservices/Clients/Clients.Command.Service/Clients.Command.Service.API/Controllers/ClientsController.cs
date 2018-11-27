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
using Services.Common.DomainObjects.Enum;
using Clients.Command.Service.API.Commands.Clients.Dto;
using Clients.Command.Service.API.Commands.Clients;
using Clients.Command.Service.API.Commands.Clients.CommandHandlers;
using Services.Common.Exceptions;
using Services.Common.Commands;
using Microsoft.AspNetCore.Authorization;

namespace Clients.Command.Service.API.Controllers
{
    [Authorize(Policy = nameof(Policies.AdvancedUsers))]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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

        // POST: api/v1/Clients/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient([FromRoute] int id, [FromBody] AlterClientCommandDto cmdDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cmdDTO.Id)
            {
                return BadRequest();
            }

            var commandResult = await new AlterClientCmdHandler()
                                        .Invoke(cmdDTO, new AlterClientCmd(),_repo);
            if (!commandResult.IsOK)
                return new ErrorResponse(commandResult).GetActionResult();
                
            return Ok(cmdDTO);
        }

        // POST: api/v1/Clients
        /// <summary>
        /// Creates a Client.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/Clients
        ///     {
        ///        "name": "Client",
        ///        "phoneNumber": "123477",
        ///        "address": {
        ///                "street": "no trang long",
        ///                "city": "hcm",
        ///                "state": "hcm",
        ///                "country": "vn",
        ///                "zipCode": "08"
        ///                }
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created Client</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>                 
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostClient([FromBody] CreateClientCommandDto cmdDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commandResult = await new CreateClientCmdHandler()
                                        .Invoke(cmdDTO, new CreateClientCmd(), _repo);
            if (!commandResult.IsOK)
                return new ErrorResponse(commandResult).GetActionResult();

            return Ok(cmdDTO);
        }

        // DELETE: api/v1/Clients/5


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

        #region private methods

        #endregion
    }
}