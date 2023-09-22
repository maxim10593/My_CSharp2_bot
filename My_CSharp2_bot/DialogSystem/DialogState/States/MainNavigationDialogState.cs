using My_CSharp2_bot.DialogSystem.DialogState.Abstract;
using My_CSharp2_bot.DialogSystem.DialogState.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace My_CSharp2_bot.DialogSystem.DialogState.States
{
    internal class MainNavigationDialogState : DialogStateBase, IDialogStateEnterAsync, IDialogStateCallbackQueryUpdate
    {
        private const string FILE_MENEGER_STATE_CALLBACK_DATA = "FILE MENEGER";

        private const string CONTROL_COMPUTER_CALLBACK_DATA = "CONTROL COMPUTER";

        private const string ABOUT_THE_BOT_CALLBACK_DATA = "ABOUT THE BOT";

        public MainNavigationDialogState(DialogStateMachine dialogStateMachine, DialogUser dialogUser) : base(dialogStateMachine, dialogUser)
        {

        }

        public async Task CallbackQueryUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if(update!.CallbackQuery!.Data == FILE_MENEGER_STATE_CALLBACK_DATA)
            {

            }
            
            if(update!.CallbackQuery!.Data == CONTROL_COMPUTER_CALLBACK_DATA)
            {

            }
            
            if(update!.CallbackQuery!.Data == ABOUT_THE_BOT_CALLBACK_DATA)
            {

            }
        }

        public async Task EnterAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            InlineKeyboardMarkup inlineKeyboardMarkup = new(new InlineKeyboardButton[][]
            {
                new InlineKeyboardButton[] {InlineKeyboardButton.WithCallbackData("Файловый проводник", FILE_MENEGER_STATE_CALLBACK_DATA)},
                new InlineKeyboardButton[] {InlineKeyboardButton.WithCallbackData("Управление компютером", CONTROL_COMPUTER_CALLBACK_DATA)},
                new InlineKeyboardButton[] {InlineKeyboardButton.WithCallbackData("О боте", ABOUT_THE_BOT_CALLBACK_DATA)}
            }
            );

            await botClient.SendTextMessageAsync(
                chatId: base.dialogUser.TelegramUserId,
                text: "Главная навигация по боту",
                replyMarkup: inlineKeyboardMarkup,
                cancellationToken: cancellationToken
                );
        }
    }
}
