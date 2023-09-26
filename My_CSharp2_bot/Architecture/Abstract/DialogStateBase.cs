using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_CSharp2_bot.Architecture.Abstract
{
    internal abstract class DialogStateBase
    {
        protected readonly DialogStateMachine stateMachine;

        public DialogStateBase(DialogStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
}
