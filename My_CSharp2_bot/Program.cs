using My_CSharp2_bot.Architecture.Test;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace My_CSharp2_bot
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // Создание нашего бота
            var botClient = new TelegramBotClient("6678742161:AAH2-0RGOa3H4M7IpNKiSdXAJITqPLHVi2U");

            using CancellationTokenSource cancellationTokenSource = new();

            DialogUserSystem userSystem = new();

            botClient.StartReceiving(updateHandler: userSystem.UpdateHandler, pollingErrorHandler: PollingErrorHandler, cancellationToken: cancellationTokenSource.Token);

            Console.ReadKey();

            cancellationTokenSource.Cancel();

            Console.WriteLine("Программа хостинга бота закрыта. Нажмите любую клавишу чтобы продолжить...");
            Console.ReadKey();
        }

        private async static Task PollingErrorHandler(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw exception;
        }
    }
}
