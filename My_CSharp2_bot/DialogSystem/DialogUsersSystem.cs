﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace My_CSharp2_bot.DialogSystem
{
    internal class DialogUsersSystem
    {
        private Dictionary<long, DialogUser> userMap = new();

        public bool ContainsDialogUser(long telegramId)
        {
            return userMap.ContainsKey(telegramId);
        }

        public void AddDialogUser(long telegramId, DialogUser user)
        {
            userMap.Add(telegramId, user);
        }

        public void RemoveDialogUser(long telegramId)
        {
            userMap.Remove(telegramId);
        }


        public async Task UpdateAsync(long telegramId, ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await this.userMap[telegramId].StateMachine.UpdateDialogStateAsync(botClient, update, cancellationToken);
        }
    }
}
