using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_CSharp2_bot.Architecture.Abstract
{
    internal abstract class DialogStateBase<TEntityId, TDialogStateMachineKey>
        where TEntityId : notnull
        where TDialogStateMachineKey : notnull
    {
        public DialogStateMachineBase<TEntityId, TDialogStateMachineKey> StateMachine { get; }
         
        public DialogStateBase(DialogStateMachineBase<TEntityId, TDialogStateMachineKey> stateMachine)
        {
            this.StateMachine = stateMachine;
        }
    }
}
