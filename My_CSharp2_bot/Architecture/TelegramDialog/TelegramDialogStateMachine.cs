using My_CSharp2_bot.Architecture.Abstract;
using My_CSharp2_bot.Architecture.Test.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace My_CSharp2_bot.Architecture.Test
{
    internal class TelegramDialogStateMachine : DialogStateMachineBase<long, string>
    {
        public TelegramDialogStateMachine(IDialogEnity<long, string> dialogEnity) : base(dialogEnity) { }

        public async Task MessageUpdateAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
        {
            if(base.CurrentState is IDialogStateMessageUpdate messageUpdate)
            {
                 await messageUpdate.MessageUpdateAsync(botClient, message, cancellationToken);
            }
        }

        public async Task SetDialogState(string key, ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(base.CurrentState == base.stateMap[key])
            {
                return;
            }

            if(CurrentState is IDialogStateOnUpdateExit exit)
            {
                await exit.ExitAsync(botClient, update, cancellationToken);
            }

            CurrentState = base.stateMap[key];

            if(CurrentState is IDialogStateOnUpdateEnter enter)
            {
                await enter.EnterAsync(botClient, update, cancellationToken);
            }
        }
    }
}
