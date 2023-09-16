using My_CSharp2_bot.DialogSystem.DialogState.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_CSharp2_bot.DialogSystem
{
    internal class DialogUser
    {
        public DialogStateMachine StateMachine { get; }

        public long TelegramUserId { get; }

        public Telegram.Bot.Types.User TelegramUser { get; }

        public DialogUser(long telegramUserId, Telegram.Bot.Types.User telegramUser)
        {
            this.TelegramUserId = telegramUserId;

            this.StateMachine = new();

            this.TelegramUser = telegramUser;
        }
    }
}
