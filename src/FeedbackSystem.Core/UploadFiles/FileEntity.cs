﻿
public class FileEntity:EntityBase, IAggregateRoot
{
  
  public required string FileName { get; set; }  
  public required string ContentType { get; set; }  
  public required byte[]? FileData { get; set; }
}
