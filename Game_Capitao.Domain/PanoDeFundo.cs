using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Capitao.Domain
{
   public class PanoDeFundo:EntityBase
    {
        public PanoDeFundo(Size bounds, Graphics screen):base(bounds,screen)
        {
            X = 0;
            Y = 0;
            Height = bounds.Height;
            Width = bounds.Width;
        }

        public override void DrawSprite()
        {
            Screen.FillRectangle(Brushes.CadetBlue, Rect);
        }
    }
}
