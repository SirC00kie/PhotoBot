using PhotoBot.Commands;
using Telegram.Bot.Types;

namespace PhotoBot.Services.CommandService;

public interface ICommandService
{
    ICommand Execute(Message message);
}