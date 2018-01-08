using System.Drawing;
using System.Windows.Forms;

namespace Engine {
    public class Player {
        public Player(Game game) {
            keyboardManager = game.KeyboardManager;
            mouseController = game.MouseController;
            Size = new SizeF(32.0f, 32.0f);
            Speed = 5.0f;
            Weapon = new Firearm(game);
        }

        readonly KeyboardManager keyboardManager;
        readonly MouseController mouseController;

        public SizeF Size { get; set; }
        public PointF Coords { get; set; }
        public float Speed { get; set; }
        public Firearm Weapon { get; set; }

        public void Spawn(float x, float y) {
            Coords = new PointF(x, y);
        }

        public void Tick() {
            if(keyboardManager.IsPressed(Keys.Up)) {
                Coords = new PointF(Coords.X, Coords.Y - Speed);
            }
            if(keyboardManager.IsPressed(Keys.Right)) {
                Coords = new PointF(Coords.X + Speed, Coords.Y);
            }
            if(keyboardManager.IsPressed(Keys.Down)) {
                Coords = new PointF(Coords.X, Coords.Y + Speed);
            }
            if(keyboardManager.IsPressed(Keys.Left)) {
                Coords = new PointF(Coords.X - Speed, Coords.Y);
            }
            if(mouseController.IsPressed(MouseButtons.Left)) {
                Weapon?.Shoot();
            }
        }

        public void Render(Graphics graphics) {
            graphics.FillRectangle(Brushes.White, Coords.X, Coords.Y, Size.Width, Size.Height);
        }
    }
}