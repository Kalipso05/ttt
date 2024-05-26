using System;
using System.Collections.Generic;

namespace RoadsOfRussiaWeb.Entities;

public partial class FilesDetail
{
    public int Id { get; set; }

    public string FileName { get; set; } = null!;

    public byte[] FileData { get; set; } = null!;

    public FileType FileType { get; set; }
}
