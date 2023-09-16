using My_CSharp2_bot.DialogSystem.DialogState.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_CSharp2_bot.DialogSystem.DialogState.Abstract
{
    internal abstract class DialogStateBase
    {
        protected readonly DialogStateMachine dialogStateMachine;

        protected readonly DialogUser dialogUser;

        public DialogStateBase(DialogStateMachine dialogStateMachine, DialogUser dialogUser)
        {
            this.dialogStateMachine = dialogStateMachine;

            this.dialogUser = dialogUser;
        }
    }
}
