using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_CSharp2_bot.Architecture.Abstract
{
    internal abstract class DialogStateBase<TDialogStateMachineKey>
        where TDialogStateMachineKey : notnull
    {
        protected readonly DialogStateMachineBase<TDialogStateMachineKey> stateMachine;
         
        public DialogStateBase(DialogStateMachineBase<TDialogStateMachineKey> stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
}
