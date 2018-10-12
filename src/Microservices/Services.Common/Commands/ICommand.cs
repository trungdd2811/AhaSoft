using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.Commands
{
    public interface ICommand<T> where T:ICommandDTO
    {
        void ApplyDTO(T cmdDTO);
    }
}
