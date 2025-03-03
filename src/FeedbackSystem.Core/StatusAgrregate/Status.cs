using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.Core.StatusAgrregate;

public class Status : EntityBase, IAggregateRoot
{
  public string StatusName { get; set; } = null!;

  public Status(int id, string statusName)
  {
    Id = id;
    StatusName = statusName;
  }
}
