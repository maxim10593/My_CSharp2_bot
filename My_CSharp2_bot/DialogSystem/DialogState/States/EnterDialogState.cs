using My_CSharp2_bot.DialogSystem.DialogState.Abstract;
using My_CSharp2_bot.DialogSystem.DialogState.Machine;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace My_CSharp2_bot.DialogSystem.DialogState.States
{
    internal class EnterDialogState : DialogStateBase, IDialogStateEnterAsync, IDialogStateCallbackQueryUpdate
    {
        private const string GO_TO_NEXT_CALLBACK_DATA = "GO TO NEXT";

        private const string MAIN_NAVIGATION_STATE_KEY = "MainNavigationState";

        private Message helloMessage;

        public EnterDialogState(DialogStateMachine dialogStateMachine, DialogUser dialogUser) : base(dialogStateMachine, dialogUser) { }

        public async Task CallbackQueryUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update?.CallbackQuery?.Data == GO_TO_NEXT_CALLBACK_DATA)
            {
                base.dialogStateMachine.AddDialogState(MAIN_NAVIGATION_STATE_KEY, new MainNavigationDialogState(base.dialogStateMachine, base.dialogUser));

                await botClient.AnswerCallbackQueryAsync(update!.CallbackQuery!.Id, cancellationToken: cancellationToken);

                await botClient.DeleteMessageAsync(update.CallbackQuery.From.Id, helloMessage.MessageId, cancellationToken);
                
                await base.dialogStateMachine.SetDialogStateAsync(MAIN_NAVIGATION_STATE_KEY, botClient, update, cancellationToken);

                return;
            }

        }

        public async Task EnterAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            long userId = base.dialogUser.TelegramUserId;

            InlineKeyboardMarkup inlineKeyboardMarkup = new(new[]
            {
                InlineKeyboardButton.WithCallbackData("Дальше", GO_TO_NEXT_CALLBACK_DATA)
            });

            this.helloMessage = await botClient.SendTextMessageAsync(
                chatId: userId,
                text: "Привет!",
                replyMarkup: inlineKeyboardMarkup,
                cancellationToken: cancellationToken
                );
        }
    }
}
