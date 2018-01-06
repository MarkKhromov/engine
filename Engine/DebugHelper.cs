using System.Drawing;

namespace Engine {
    static class DebugHelper {
        public static void RenderCoords(Graphics graphics, Player player) {
            using(var font = new Font(FontFamily.GenericMonospace, 6.0f)) {
                graphics.DrawString($"X: {player.Coords.X}", font, Brushes.White, player.Coords.X + player.Size.Width + 3.0f, player.Coords.Y);
                graphics.DrawString($"Y: {player.Coords.Y}", font, Brushes.White, player.Coords.X + player.Size.Width + 3.0f, player.Coords.Y + 8.0f);
            }
        }
    }
}