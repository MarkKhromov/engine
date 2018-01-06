using System.Drawing;

namespace Engine {
    public class Player {
        public Player(Game game) {
            this.game = game;
            Size = new SizeF(32.0f, 32.0f);
        }

        readonly Game game;

        public SizeF Size { get; set; }
        public PointF Coords { get; set; }

        public void Spawn(float x, float y) {
            Coords = new PointF(x, y);
        }

        public void Render(Graphics graphics) {
            graphics.FillRectangle(Brushes.White, Coords.X, Coords.Y, Size.Width, Size.Height);
        }
    }
}