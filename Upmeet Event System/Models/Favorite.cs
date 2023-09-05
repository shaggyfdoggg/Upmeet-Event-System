using System;
using System.Collections.Generic;

namespace Upmeet_Event_System.Models;

public partial class Favorite
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Username { get; set; }

    public int? EventId { get; set; }

    public virtual Event? Event { get; set; }
}
