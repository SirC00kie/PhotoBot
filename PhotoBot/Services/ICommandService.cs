using PhotoBot.Commands;
using Telegram.Bot.Types;

namespace PhotoBot.Services;

public interface ICommandService
{
    ICommand Execute(Message message);
}