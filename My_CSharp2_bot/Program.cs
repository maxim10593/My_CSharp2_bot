using My_CSharp2_bot.DialogSystem;
using My_CSharp2_bot.DialogSystem.DialogState.States;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace My_CSharp2_bot
{
    internal static class Program
    {
        private static DialogUsersSystem dialogUsersSystem = new();

        public static void Main(string[] args)
        {
            var botClient = new TelegramBotClient("6678742161:AAH2-0RGOa3H4M7IpNKiSdXAJITqPLHVi2U");

            using CancellationTokenSource cancellationTokenSource = new();

            botClient.StartReceiving(
                updateHandler: UpdateHandlerAsync,
                pollingErrorHandler: PollingErrorHandler,
                cancellationToken: cancellationTokenSource.Token
                );

            Console.ReadLine();

            cancellationTokenSource.Cancel();

            Console.ReadLine();
        }

        private async static Task UpdateHandlerAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            const string ENTER_DIALOG_STATE_KEY = "EnterDialogState";

            if(update?.Message?.From != null)
            {
                User fromUser = update.Message.From;

                if (!dialogUsersSystem.ContainsDialogUser(fromUser.Id))
                {
                    DialogUser newDialogUser = new(fromUser);

                    dialogUsersSystem.AddDialogUser(newDialogUser);

                    newDialogUser.StateMachine.AddDialogState(ENTER_DIALOG_STATE_KEY, new EnterDialogState(newDialogUser.StateMachine, newDialogUser));

                    await newDialogUser.StateMachine.SetDialogStateAsync(ENTER_DIALOG_STATE_KEY, botClient, update, cancellationToken);
                }

                await dialogUsersSystem.UpdateAsync(fromUser.Id, botClient, update, cancellationToken);
            }
        }

        private async static Task PollingErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
