// using FeedbackSystem.Core.Interfaces;
//
// namespace FeedbackSystem.Core.CategoryAggregate.Handler;
//
// internal class CategoryDeletedHandler(ILogger<CategoryDeletedHandler> logger,
//   IEmailSender emailSender) : INotificationHandler<CategoryDeletedEvent>
// {
//   public async Task Handle(CategoryDeletedEvent domainEvent, CancellationToken cancellationToken)
//   {
//     logger.LogInformation("Handling Contributed Deleted event for {categoryId}", domainEvent.categoryId);
//
//     await emailSender.SendEmailAsync("to@test.com",
//       "from@test.com",
//       "Contributor Deleted",
//       $"Contributor with id {domainEvent.categoryId} was deleted.");
//   }
// }


