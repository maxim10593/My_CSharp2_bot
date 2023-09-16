using My_CSharp2_bot.DialogSystem.DialogState.Abstract;
using My_CSharp2_bot.DialogSystem.DialogState.Machine;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace My_CSharp2_bot.DialogSystem.DialogState.States
{
    internal class EnterDialogState : DialogStateBase, IDialogStateEnterAsync
    {
        public EnterDialogState(DialogStateMachine dialogStateMachine, DialogUser dialogUser) : base(dialogStateMachine, dialogUser) { }

        public async Task EnterAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

        }
    }
}
