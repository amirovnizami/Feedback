using System.Windows.Input;

namespace FeedbackSystem.UseCases.Uploads;

public record UploadFileCommand(string fileName,string contentType,byte[]? fileData):ICommand<Result<int>>
{
  
}
