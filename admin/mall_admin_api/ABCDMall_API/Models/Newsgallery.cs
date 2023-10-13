using System;
using System.Collections.Generic;

namespace ABCDMall_API.Models;

public partial class Newsgallery
{
    public int Id { get; set; }

    public string? CoverImg { get; set; }

    public string? Description { get; set; }

    public string? Thumbnail { get; set; }
}
