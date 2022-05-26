using Game_Capitao.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Game_Capitao.Win32
{
    public partial class Principal : Form
    {
        Bitmap screenBuffer;
        Graphics screenPainter;
        GameObjects gameObjects;
        DispatcherTimer gameTimer;
        Chao chao;
        Player player;
        public Principal()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
            //TopMost = true;
            screenBuffer = new Bitmap(Bounds.Width, Bounds.Height);
            screenPainter = Graphics.FromImage(screenBuffer);
            player = new Player(Bounds.Size, screenPainter);
            chao = new Chao(Bounds.Size, screenPainter);

            gameObjects = new GameObjects();
            gameObjects.Add(new PanoDeFundo(Bounds.Size, screenPainter));
            gameObjects.Add(chao);
            gameObjects.Add(player);

            gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(80);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

        }

        public void GameLoop(object sender, EventArgs e)
        {
            foreach (var item in gameObjects)
            {
                item.DrawSprite();
                item.Gravity();
            }
            Invalidate();
        }

        private void Principal_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawImage(screenBuffer, 0, 0);
        }

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            player.isJumping = false;

            if (e.KeyCode == Keys.Escape)
                Close();
            if (e.KeyCode == Keys.Right)
                player.MoveRight();
            if (e.KeyCode == Keys.Up)
                player.MoveJump();
            if (e.KeyCode == Keys.Down)
                player.MoveDown();
            if (e.KeyCode == Keys.Left)
                player.MoveLeft();
        }

        private void Principal_KeyUp(object sender, KeyEventArgs e)
        {
            if (!player.isJumping)
                player.MoveStay();
            else
                player.MoveLand();
        }
    }
}
