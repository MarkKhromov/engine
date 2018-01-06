using System.Drawing;
using System.Windows.Forms;

namespace Engine {
    public class Player {
        public Player(Game game) {
            this.game = game;
            Size = new SizeF(32.0f, 32.0f);
            Speed = 5.0f;
        }

        readonly Game game;

        public SizeF Size { get; set; }
        public PointF Coords { get; set; }
        public float Speed { get; set; }

        public void Spawn(float x, float y) {
            Coords = new PointF(x, y);
        }

        public void Tick() {
            if(game.KeyboardManager.IsPressed(Keys.Up)) {
                Coords = new PointF(Coords.X, Coords.Y - Speed);
            }
            if(game.KeyboardManager.IsPressed(Keys.Right)) {
                Coords = new PointF(Coords.X + Speed, Coords.Y);
            }
            if(game.KeyboardManager.IsPressed(Keys.Down)) {
                Coords = new PointF(Coords.X, Coords.Y + Speed);
            }
            if(game.KeyboardManager.IsPressed(Keys.Left)) {
                Coords = new PointF(Coords.X - Speed, Coords.Y);
            }
        }

        public void Render(Graphics graphics) {
            graphics.FillRectangle(Brushes.White, Coords.X, Coords.Y, Size.Width, Size.Height);
        }
    }
}