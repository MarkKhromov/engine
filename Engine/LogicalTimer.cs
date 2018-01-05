using System;

namespace Engine {
    public class LogicalTimer {
        public LogicalTimer(int fps, Action action) {
            this.action = action;
            tickTimeSpan = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / fps);
            nextTickTime = DateTime.Now;
        }

        readonly Action action;
        readonly TimeSpan tickTimeSpan;
        DateTime nextTickTime;

        public void Tick() {
            if((nextTickTime - DateTime.Now).Ticks <= 0) {
                nextTickTime += tickTimeSpan;
                action();
            }
        }
    }
}