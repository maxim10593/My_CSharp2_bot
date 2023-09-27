using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_CSharp2_bot.Architecture.Abstract
{
    internal abstract class DialogStateBase<TDialogStateMachineKey, TEntityId>
        where TDialogStateMachineKey : notnull
        where TEntityId : notnull
    {
        protected readonly DialogStateMachineBase<TDialogStateMachineKey, TEntityId> stateMachine;
         
        public DialogStateBase(DialogStateMachineBase<TDialogStateMachineKey, TEntityId> stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
}
