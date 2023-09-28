using My_CSharp2_bot.Architecture.Abstract;
using My_CSharp2_bot.Architecture.Test.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace My_CSharp2_bot.Architecture.Test.States
{
    internal class StartTelegramDialogState : DialogStateBase<long, string>, IDialogStateOnUpdateEnter, IDialogStateMessageUpdate
    {
        public StartTelegramDialogState(DialogStateMachineBase<long, string> stateMachine) : base(stateMachine) { }

        public async Task EnterAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Enter", cancellationToken: cancellationToken);
        }

        public async Task MessageUpdateAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Message update", cancellationToken: cancellationToken);
        }
    }
}
