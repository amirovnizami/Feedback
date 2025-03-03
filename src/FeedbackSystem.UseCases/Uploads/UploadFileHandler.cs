namespace FeedbackSystem.UseCases.Uploads;

public class UploadFileHandler(IRepository<FileEntity> repository) : ICommandHandler<UploadFileCommand, Result<int>>
{
  public async Task<Result<int>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
  {
    try
    {
      var uploadFile = new FileEntity
      {
        FileName = request.fileName, ContentType = request.contentType, FileData = request.fileData,
      };

      await repository.AddAsync(uploadFile, cancellationToken);

      return Result<int>.Success(uploadFile.Id);
    }
    catch (Exception ex)
    {
      return Result.Error(ex.Message);
    }
  }
}
