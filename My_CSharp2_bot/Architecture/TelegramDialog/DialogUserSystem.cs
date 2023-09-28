using My_CSharp2_bot.Architecture.Abstract;
using My_CSharp2_bot.Architecture.Test.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace My_CSharp2_bot.Architecture.Test
{
    internal class DialogUserSystem : DialogEntitySystemBase<long, string>
    {
        public async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update.Type == UpdateType.Message)
            {
                if(update.Message!.From == null)
                {
                    return;
                }

                Telegram.Bot.Types.User fromUser = update.Message!.From;

                TelegramDialogStateMachine fromUserTelegramDialogStateMachine;

                if(!base.ContainsEntity(fromUser.Id))
                {
                    base.AddEntity(new DialogUser(fromUser, this));

                    fromUserTelegramDialogStateMachine = (TelegramDialogStateMachine)(base.GetEnity(fromUser.Id).DialogStateMachine);

                    base.GetEnity(fromUser.Id).DialogStateMachine.
                        AddState("Start", new StartTelegramDialogState(base.GetEnity(fromUser.Id).DialogStateMachine));

                    await fromUserTelegramDialogStateMachine.SetDialogState("Start", botClient, update, cancellationToken);
                }
                else
                {
                    fromUserTelegramDialogStateMachine = (TelegramDialogStateMachine)(base.GetEnity(fromUser.Id).DialogStateMachine);
                }

                await fromUserTelegramDialogStateMachine.MessageUpdateAsync(botClient, update.Message, cancellationToken);
            }
        }
    }
}
