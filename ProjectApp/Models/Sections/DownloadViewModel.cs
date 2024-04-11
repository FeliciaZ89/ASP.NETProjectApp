using ProjectApp.Models.Components;

namespace ProjectApp.Models.Sections;

public class DownloadViewModel
{
    public string? Id { get; set; }
    public ImageViewModel DownloadImage { get; set; } = null!;
    public string? Title { get; set; }

    public List<string>? TextItems { get; set; }

    public List<StoreViewModel>? Stores { get; set; }

    public List<string>? Description { get; set; }
}

