using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
public class ToolsItemEntity
    {
        public int Id { get; set; }
        public int ToolId { get; set; }
        public ToolsEntity Tools { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
