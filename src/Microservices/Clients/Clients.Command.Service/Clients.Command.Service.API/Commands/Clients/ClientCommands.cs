using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Common.Commands;
using Clients.Command.Service.API.Commands.Clients.Dto;
using Clients.Command.Service.Domain.AggregatesModel.ClientAggregate;

namespace Clients.Command.Service.API.Commands.Clients
{
    public class CreateClientCmd : ICommand<CreateClientCommandDto>
    {
        public CreateClientCommandDto DTO { get; private set; }
        public void ApplyDTO(CreateClientCommandDto cmdDTO)
        {
            DTO = cmdDTO;
            DTO.Id = 0;
            DTO.CreatedDate = DateTime.Now;
            DTO.UpdatedDate = DateTime.Now;
        }
    }

    public class AlterClientCmd : ICommand<AlterClientCommandDto>
    {
        public AlterClientCommandDto DTO { get; private set; }
        public void ApplyDTO(AlterClientCommandDto cmdDTO)
        {
            DTO = cmdDTO;
            DTO.UpdatedDate = DateTime.Now;
        }
    }

    
}
