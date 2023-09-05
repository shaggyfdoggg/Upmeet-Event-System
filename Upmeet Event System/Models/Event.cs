using System;
using System.Collections.Generic;

namespace Upmeet_Event_System.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? DateTime { get; set; }

    public string? Location { get; set; }

    public int? Attending { get; set; }
}
