namespace ProjectApp.Models.Components;

public class LinkViewModel
{
    public string ControllerName { get; set; } = null!;
    public string ActionName { get; set; } = null!;
    public string? Fragment { get; set; }
    public string Text { get; set; } = null!;

    public string? Url { get; set; }
}
