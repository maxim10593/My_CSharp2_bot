using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace My_CSharp2_bot.Architecture.Test.Abstract
{
    internal interface IDialogStateMessageUpdate
    {
        Task MessageUpdateAsync(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken);
    }
}
