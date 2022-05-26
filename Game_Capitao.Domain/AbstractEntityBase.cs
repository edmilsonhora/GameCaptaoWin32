using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Capitao.Domain
{
    public abstract class EntityBase
    {
        public const int GRAVITY = 3;
        public const int JUMPFORCE = 18;
        public EntityBase(Size bounds, Graphics screen)
        {
            Bounds = bounds;
            Screen = screen;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Size Bounds { get; set; }
        public Graphics Screen { get; set; }
        public Rectangle Rect { get { return new Rectangle(X, Y, Width, Height); } }
        public int SpeedWalk { get; set; }
        public int FallVelocity { get; set; }


        public abstract void DrawSprite();


        public virtual void Gravity()
        {
            
        }
        public virtual void MoveUp()
        {
            Y -= SpeedWalk;
        }

        public virtual void MoveDown()
        {
            Y += SpeedWalk;
        }

        public virtual void MoveLeft()
        {
            X -= SpeedWalk;
        }

        public virtual void MoveRight()
        {
            X += SpeedWalk;
        }

        


    }
}
