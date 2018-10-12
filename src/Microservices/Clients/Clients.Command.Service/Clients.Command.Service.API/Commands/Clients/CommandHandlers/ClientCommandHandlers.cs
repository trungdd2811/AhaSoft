using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Common.Commands;
using Clients.Command.Service.API.Commands.Clients;
using Clients.Command.Service.Domain.AggregatesModel.ClientAggregate;
using Services.Common.DomainObjects.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Common.Exceptions;
using Clients.Command.Service.API.Commands.Clients.Dto;

namespace Clients.Command.Service.API.Commands.Clients.CommandHandlers
{
    public class CreateClientCmdHandler : CommandHandler<CreateClientCommandDto,
                                                         CreateClientCmd,
                                                         Client,
                                                         IClientRepository>
    {
        public override async Task<CommandResult> Handle(CreateClientCmd cmd, IClientRepository repo)
        {

            try
            {
                var command = cmd ?? throw new ArgumentNullException(nameof(cmd));
                var client = new Client(command.DTO.Name, command.DTO.PhoneNumber, command.DTO.Address, command.DTO.CreatedDate, command.DTO.CreatedDate);

                repo.Add(client);
                await repo.UnitOfWork.SaveChangesAsync();
                command.DTO.Id = client.Id;
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex, ErrorCodes.InternalError);

            }
            return new CommandResult(true);
        }
    }

    public class AlterClientCmdHandler : CommandHandler<AlterClientCommandDto, 
                                                        AlterClientCmd,
                                                        Client, 
                                                        IClientRepository>
    {
        public override async Task<CommandResult> Handle(AlterClientCmd cmd, IClientRepository repo)
        {
            try
            {
                if (cmd == null) throw new ArgumentNullException(nameof(cmd));

                var existClient = await repo.GetAsync(cmd.DTO.Id);
                if (existClient != null && existClient.Id > 0)
                {
                    existClient.UpdatedDate = cmd.DTO.UpdatedDate;
                    existClient.Name = cmd.DTO.Name;
                    existClient.PhoneNumber = cmd.DTO.PhoneNumber;
                    existClient.Address = cmd.DTO.Address;
                    repo.Update(existClient);
                }
                else return new CommandResult(false, new Exception($"Not Found. Id: {cmd.DTO.Id}"), ErrorCodes.ObjectNotFound);
                await repo.UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex, ErrorCodes.InternalError);
            }
            return new CommandResult(true);
        }
    }
}
