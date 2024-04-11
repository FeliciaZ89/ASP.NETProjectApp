using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities;

public class LightDarkSliderEntity
{
    public string? Id { get; set; }

    public string? TitleDark { get; set; }
    public string? TitleLight { get; set; }
    public string Image { get; set; } = null!;
    public string AltText { get; set; } = null!;
}
