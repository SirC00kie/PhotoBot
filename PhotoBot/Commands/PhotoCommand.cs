using PhotoBot.Services.PhotoService;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PhotoBot.Commands;

public class PhotoCommand : ICommand
{
    private readonly IPhotoService _photoService;

    public PhotoCommand(IPhotoService photoService)
    {
        _photoService = photoService;
    }

    public string Command => "/photo";
    public async Task ExecuteAsync(Message message, ITelegramBotClient botClient)
    {
        var messageText = message.Text;
        var commandLength = Command.Length;
        
        if (messageText?.Length <= commandLength)
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"Запрос к фото введен неверно.");
            return;
        }
        var query = messageText?.Substring(commandLength + 1);

        var photo = await _photoService.GetPhotoAsync(query!);

        if (photo == null)
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"Команда введена неверна. Проверьте введенный запрос: {query}");
            return;
        }

        var urls = photo.Urls;
        var text = 
            $"Описание: {photo.Description} \n"+
            $"Фото: {urls.Regular}";
            
        await botClient.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: text);
    }
}