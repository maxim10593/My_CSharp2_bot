using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace My_CSharp2_bot.DialogSystem.DialogState.Abstract
{
    internal interface IDialogStateUpdateAsync
    {
        Task UpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken);
    }
}
