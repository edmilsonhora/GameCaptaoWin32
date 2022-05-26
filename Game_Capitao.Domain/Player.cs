using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Capitao.Domain
{
    public class Player : EntityBase
    {

        int i = 0;
        Acao acao = Acao.Stay;
       public bool isJumping = false;
        enum Acao { Stay, Walk, Jump, Land, WalkBack }
        public Player(Size bounds, Graphics screen) : base(bounds, screen)
        {
            X = 40;
            Y = 40;
            SpeedWalk = 5;
            Height = 92;
            Width = 62;
        }
        public override void DrawSprite()
        {

            switch (acao)
            {
                case Acao.Stay:
                    Staying();
                    break;
                case Acao.Walk:
                    Walking();
                    break;
                case Acao.Jump:
                    Jumping();
                    break;
                case Acao.Land:
                    Landing();
                    break;
                case Acao.WalkBack:
                    WalkingBack();
                    break;
                default:
                    Staying();
                    break;
            }

        }

        public override void MoveRight()
        {
            base.MoveRight();
            acao = Acao.Walk;

        }

        public override void MoveLeft()
        {
            base.MoveLeft();
            acao = Acao.WalkBack;
        }

        public override void Gravity()
        {
            FallVelocity += GRAVITY;
            Y += FallVelocity;
            if (Y >= Bounds.Height - 140)
            {
                Y = Bounds.Height - 140;
                acao = Acao.Stay;
                isJumping = false;

            }
            else
            {
                if (!isJumping)
                    acao = Acao.Land;
            }
        }

        public void MoveJump()
        {
            isJumping = true;
            FallVelocity = -JUMPFORCE;
            acao = Acao.Jump;
        }

        public void MoveLand()
        {
            isJumping = false;
            acao = Acao.Land;
        }


        public void MoveStay()
        {
            acao = Acao.Stay;
        }

        private void Walking()
        {
            if (i > 5) i = 0;

            Bitmap[] imgs = { Media.walk_1, Media.walk_2, Media.walk_3, Media.walk_4, Media.walk_5, Media.walk_6 };

            imgs[i].MakeTransparent(Color.White);
            Screen.DrawImage(imgs[i], Rect);
            i++;
            if (i > 5) i = 0;
        }

        private void WalkingBack()
        {
            if (i > 5) i = 0;

            Bitmap[] imgs = { Media.walk_1, Media.walk_2, Media.walk_3, Media.walk_4, Media.walk_5, Media.walk_6 };

            imgs[i].MakeTransparent(Color.White);
            imgs[i].RotateFlip(RotateFlipType.Rotate180FlipY);
            Screen.DrawImage(imgs[i], Rect);
            i++;
            if (i > 5) i = 0;
        }

        private void Staying()
        {
            if (i > 2) i = 0;
            acao = Acao.Stay;
            Bitmap[] imgs = { Media.Stay_1, Media.Stay_2, Media.Stay_3 };

            imgs[i].MakeTransparent(Color.White);
            Screen.DrawImage(imgs[i], Rect);
            i++;
            if (i > 2) i = 0;
        }

        private void Jumping()
        {
            if (i > 5) i = 0;

            Bitmap[] imgs = { Media.Jump_1, Media.Jump_2, Media.Jump_3, Media.Jump_4, Media.Jump_5, Media.Jump_6 };

            imgs[i].MakeTransparent(Color.White);
            Screen.DrawImage(imgs[i], Rect);
            i++;
            if (i > 5) i = 0;
        }

        private void Landing()
        {
            if (i > 1) i = 0;

            Bitmap[] imgs = { Media.Jump_7, Media.Jump_7, Media.Jump_7, Media.Jump_8 };

            imgs[i].MakeTransparent(Color.White);
            Screen.DrawImage(imgs[i], Rect);
            i++;
            if (i > 1) i = 0;
        }

    }
}
