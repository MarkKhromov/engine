using System.Drawing;

namespace Engine {
    // TODO: Abstract class
    public class Firearm {
        public Firearm(Game game) {
            this.game = game;
        }

        readonly Game game;

        protected Player Player => game.Player;

        public void Shoot() {
            var from = new PointF(Player.Coords.X + Player.Size.Width / 2.0f, Player.Coords.Y + Player.Size.Height / 2.0f);
            var to = game.MouseController.Coords;
            var bullet = new Bullet(from, to);
            game.Bullets.Add(bullet);
        }
    }
}