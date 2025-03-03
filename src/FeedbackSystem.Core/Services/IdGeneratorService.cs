using FeedbackSystem.Core.Interfaces;

namespace FeedbackSystem.Core.Services;

public class IdGeneratorService : IIdGeneratorService
{
  private static readonly Random random = new Random();

  public string CustomGenerateId()
  {
    const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string prefix = new string(Enumerable.Repeat(letters, 2)
      .Select(s => s[random.Next(s.Length)]).ToArray());
    string numbers = random.Next(10000000, 99999999).ToString();

    return $"{prefix}{numbers}";
  }
}
