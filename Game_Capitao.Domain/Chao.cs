using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Capitao.Domain
{
    public class Chao : EntityBase
    {
        public Chao(Size bounds, Graphics screen) : base(bounds, screen)
        {
            X = 0;
            Y = bounds.Height - 50;
            Height = 50;
            Width = bounds.Width;
        }

        public override void DrawSprite()
        {
            Screen.FillRectangle(Brushes.Bisque, Rect);
        }
    }
}
