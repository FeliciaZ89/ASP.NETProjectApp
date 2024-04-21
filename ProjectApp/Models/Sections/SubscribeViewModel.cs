using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Models.Sections;

public class SubscribeViewModel
{
    [Display(Name = "Email address", Prompt = "Your email", Order = 0)]
    [DataType(DataType.EmailAddress)]
    [Required]
    public string Email { get; set; } = null!;

    public bool DailyNewsletter { get; set; }
    public bool AdvertisingUpdates { get; set; }
    public bool WeekinReview { get; set; }
    public bool EventUpdates { get; set; }
    public bool StartupsWeekly { get; set; }
    public bool Podcasts { get; set; }


}
