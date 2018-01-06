using System.Drawing;

namespace Engine {
    public class Grid {
        public Grid(Game game) {
            this.game = game;
            CellSize = new SizeF(32.0f, 32.0f);
        }

        readonly Game game;

        public SizeF CellSize { get; set; }

        public void Tick() { }

        public void Render(Graphics graphics) {
            using(var pen = new Pen(Color.FromArgb(128, Color.White))) {
                for(var x = CellSize.Width; x < game.WindowSize.Width; x += CellSize.Width) {
                    graphics.DrawLine(pen, new PointF(x, 0.0f), new PointF(x, game.WindowSize.Height));
                }
                for(var y = CellSize.Height; y < game.WindowSize.Height; y += CellSize.Height) {
                    graphics.DrawLine(pen, new PointF(0.0f, y), new PointF(game.WindowSize.Width, y));
                }
            }
        }
    }
}