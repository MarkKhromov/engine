using System;
using System.Drawing;

namespace Engine {
    public class Bullet {
        public Bullet(PointF from, PointF to) {
            this.from = from;
            this.to = to;
            Coords = from;
            Speed = 10.0f;
            Size = new SizeF(8.0f, 8.0f);
            var vector = new PointF(to.X - from.X, to.Y - from.Y);
            var vectorLength = Convert.ToSingle(Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y));
            var steps = vectorLength / Speed;
            delta = new PointF((to.X - from.X) / steps, (to.Y - from.Y) / steps);
        }

        readonly PointF from;
        readonly PointF to;
        readonly PointF delta;

        public SizeF Size { get; set; }
        public PointF Coords { get; set; }
        public float Speed { get; set; }

        public void Tick() {
            Coords = new PointF(Coords.X + delta.X, Coords.Y + delta.Y);
        }

        public void Render(Graphics graphics) {
            graphics.FillEllipse(Brushes.White, Coords.X, Coords.Y, Size.Width, Size.Height);
        }
    }
}