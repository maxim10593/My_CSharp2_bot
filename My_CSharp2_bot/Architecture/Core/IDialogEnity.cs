using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_CSharp2_bot.Architecture.Abstract
{
    internal interface IDialogEnity<TEntityId, TDialogStateMachineKey>
        where TEntityId : notnull
        where TDialogStateMachineKey : notnull
    {
        DialogStateMachineBase<TEntityId, TDialogStateMachineKey> DialogStateMachine { get; }

        TEntityId Id { get; }

        DialogEntitySystemBase<TEntityId, TDialogStateMachineKey> EntitySystem { get; }
    }
}
