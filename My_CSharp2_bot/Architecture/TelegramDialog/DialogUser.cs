using My_CSharp2_bot.Architecture.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_CSharp2_bot.Architecture.Test
{
    internal class DialogUser : IDialogEnity<long, string>
    {
        public DialogUser(Telegram.Bot.Types.User telegramUser, DialogUserSystem dialogUserSystem)
        {
            this.telegramUser = telegramUser;

            this.dialogStateMachine = new(this);

            this.dialogUserSystem = dialogUserSystem;
        }

        private readonly DialogUserSystem dialogUserSystem;

        private readonly Telegram.Bot.Types.User telegramUser;

        private readonly TelegramDialogStateMachine dialogStateMachine;

        public DialogStateMachineBase<long, string> DialogStateMachine => this.dialogStateMachine;

        public long Id => this.telegramUser.Id;

        public DialogEntitySystemBase<long, string> EntitySystem => this.dialogUserSystem;
    }
}
