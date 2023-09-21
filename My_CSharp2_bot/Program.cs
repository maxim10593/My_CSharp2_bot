using My_CSharp2_bot.DialogSystem;
using My_CSharp2_bot.DialogSystem.DialogState.States;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace My_CSharp2_bot
{
    internal static class Program
    {
        // Диалоговая система
        private static DialogUsersSystem dialogUsersSystem = new();

        public static void Main(string[] args)
        {
            // Создание нашего бота
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

        // Метод которий вызивается при каждом обновлении телеграм бота
        // (Отправка сообщений боту, например)
        private async static Task UpdateHandlerAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Ключ от "входного состояния"
            // В это состояние входят пользователи которые еще не занесены в диалогувую систему
            const string ENTER_DIALOG_STATE_KEY = "EnterDialogState";

            // Если отправитель есть
            if(update?.Message?.From != null)
            {
                User fromUser = update.Message.From;

                // Если пользователя нету в диалоговой системе,
                // То добавляем его
                if (!dialogUsersSystem.ContainsDialogUser(fromUser.Id))
                {
                    DialogUser newDialogUser = new(fromUser);

                    dialogUsersSystem.AddDialogUser(newDialogUser);

                    // Добавляем "входное состояние"
                    // Новому диалоговому пользователю
                    newDialogUser.StateMachine.AddDialogState(ENTER_DIALOG_STATE_KEY, new EnterDialogState(newDialogUser.StateMachine, newDialogUser));

                    await newDialogUser.StateMachine.SetDialogStateAsync(ENTER_DIALOG_STATE_KEY, botClient, update, cancellationToken);
                }

                // Вызиваем обновление у диалогой системе
                await dialogUsersSystem.UpdateAsync(fromUser.Id, botClient, update, cancellationToken);
            }
        }

        private async static Task PollingErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
