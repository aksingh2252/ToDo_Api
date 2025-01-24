using System;
using System.Collections.Generic;

namespace TodoDetails_Api.Models;

public partial class TitleDetail
{
    public int Titleid { get; set; }

    public string TitleDetails { get; set; } = null!;

    public byte Status { get; set; }
}
