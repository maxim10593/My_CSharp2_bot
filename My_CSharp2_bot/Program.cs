﻿using Telegram.Bot;
using Telegram.Bot.Types;

namespace My_CSharp2_bot
{
    internal class Program
    {
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

        }

        private async static Task PollingErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
