using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Interfaces;
namespace Services.Common.Commands
{
    public abstract class CommandHandler<TDto, TCmd, TEntity, TRepository> 
        where TDto: ICommandDTO
        where TCmd: ICommand<TDto>
        where TEntity: IAggregateRoot
        where TRepository: IRepository<TEntity>
    {
        public async Task<CommandResult> Invoke(TDto dto, TCmd cmd, TRepository repo)
        {
            cmd.ApplyDTO(dto);
            return await Handle(cmd, repo);

        }
        public abstract Task<CommandResult> Handle(TCmd cmd, TRepository repo);
    }
}
