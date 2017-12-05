using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GreenHomeAdvisor.Models
{
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public Color BackgroundColor { get; set; }
        public Type TargetType { get; set; }

        public MasterMenuItem(string title, Color color, Type target)
        {
            this.Title = title;
            this.BackgroundColor = color;
            this.TargetType = target;
        }

    }
}
