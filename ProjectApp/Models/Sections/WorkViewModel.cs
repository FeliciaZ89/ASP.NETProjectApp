using ProjectApp.Models.Components;

namespace ProjectApp.Models.Sections;

public class WorkViewModel
{
    public string? Id { get; set; }

    public string? Title { get; set; }
    public ImageViewModel DashboardImage { get; set; } = null!;
    public List<string>? TextItems { get; set; }
    public LinkViewModel Link { get; set; } = new LinkViewModel();
}
