namespace ProjectApp.Models.Components;

public class StoreViewModel
{
    public string? Name { get; set; }
    public ImageViewModel RatingImage { get; set; } = null!;
    public string? Highlight { get; set; }
    public string? Rating { get; set; }
    public string? Reviews { get; set; }
    public ImageViewModel StoreLogo { get; set; } = null!;
    public LinkViewModel StoreLink { get; set; } = null!;
}

