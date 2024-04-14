using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCode.Models
{
    public class MenuModel
    {
        public string Title { get; set; }
        public string Icon { get; set; }

        public MenuModel(string title, string icon)
        {
            Title = title;
            Icon = icon;
        }
    }
}
