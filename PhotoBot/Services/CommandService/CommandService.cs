using PhotoBot.Commands;
using PhotoBot.Services.PhotoService;
using Telegram.Bot.Types;

namespace PhotoBot.Services.CommandService;

public class CommandService : ICommandService
{
    private readonly ICommand _command;
    private readonly IReadOnlyCollection<ICommand> _commands;

    public CommandService( IPhotoService photoService)
    {
        _command = new BaseCommand();
        _commands = new ICommand[]
        {
            new HelloCommand(),
            new PhotoCommand(photoService)
        };
    }

    public ICommand Execute(Message message)
    {
        var messageText = message.Text;

        var command = _commands.SingleOrDefault(c => c.Command.Length <= messageText.Length &&
                                                     c.Command == messageText.Substring(0, c.Command.Length));

        if (command != null)
        {
            return command;
        }

        return _command;
    }
}