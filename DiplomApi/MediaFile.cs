using System;
using System.Collections.Generic;

namespace DiplomApi
{
    public partial class MediaFile
    {
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public string? Title { get; set; }
        public string? Midiatype { get; set; }
    }
}
