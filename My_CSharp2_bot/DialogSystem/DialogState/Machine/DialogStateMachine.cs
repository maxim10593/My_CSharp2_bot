using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using My_CSharp2_bot.DialogSystem.DialogState.Abstract;

namespace My_CSharp2_bot.DialogSystem.DialogState.Machine
{
    internal class DialogStateMachine
    {
        private Dictionary<string, DialogStateBase> dialogStateMap = new();

        private DialogStateBase? currentDialogState;

        public void AddDialogState(string key, DialogStateBase state)
        {
            this.dialogStateMap.Add(key, state);
        }

        public void RemoveDialogState(string key)
        {
            this.dialogStateMap.Remove(key);
        }

        public async Task SetDialogStateAsync(string key, ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (currentDialogState == dialogStateMap[key])
            {
                return;
            }

            if (currentDialogState is IDialogStateExitAsync dialogStateExitAsync)
            {
                await dialogStateExitAsync.ExitAsync(botClient, update, cancellationToken);
            }

            currentDialogState = dialogStateMap[key];

            if (currentDialogState is IDialogStateEnterAsync dialogStateEnterAsync)
            {
                await dialogStateEnterAsync.EnterAsync(botClient, update, cancellationToken);
            }
        }

        public async Task UpdateDialogStateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (currentDialogState is IDialogStateUpdateAsync dialogStateUpdateAsync)
            {
                await dialogStateUpdateAsync.UpdateAsync(botClient, update, cancellationToken);
            }
        }

        public async Task UpdateCallbackQueryAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (currentDialogState is IDialogStateCallbackQueryUpdate dialogStateCallbackQueryUpdate)
            {
                await dialogStateCallbackQueryUpdate.CallbackQueryUpdateAync(botClient, update, cancellationToken);
            }
        }
    }
}
