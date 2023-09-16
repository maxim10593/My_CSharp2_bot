using My_CSharp2_bot.DialogState.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_CSharp2_bot.DialogState.Abstract
{
    internal abstract class DialogStateBase
    {
        protected readonly DialogStateMachine dialogStateMachine;

        public DialogStateBase(DialogStateMachine dialogStateMachine)
        {
            this.dialogStateMachine = dialogStateMachine;
        }
    }
}
