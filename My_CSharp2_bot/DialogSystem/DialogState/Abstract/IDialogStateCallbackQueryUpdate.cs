using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace My_CSharp2_bot.DialogSystem.DialogState.Abstract
{
    internal interface IDialogStateCallbackQueryUpdate
    {
        Task CallbackQueryUpdateAync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}
