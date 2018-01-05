using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Engine {
    public class Game {
        public Game(Form form) {
            this.form = form;
            PrepareForm();
            thread = new Thread(new ThreadStart(() => {
                IsRunning = true;
                var logicalTimer = new LogicalTimer(60, () => {
                    // Render
                    form.Invalidate();
                    Tick();
                });
                while(IsRunning) {
                    logicalTimer.Tick();
                }
            }));
            IsRunning = false;
        }

        readonly Form form;
        readonly Thread thread;

        public bool IsRunning { get; private set; }

        public void Start() {
            thread.Start();
        }

        public void Stop() {
            IsRunning = false;
            thread.Join();
        }

        void Tick() { }

        void Render(Graphics graphics) { }

        void PrepareForm() {
            FormClosingEventHandler closingHandler = null;
            PaintEventHandler paintHandler = null;
            closingHandler = (s, e) => {
                form.FormClosing -= closingHandler;
                form.Paint -= paintHandler;
                Stop();
            };
            form.FormClosing += closingHandler;
            paintHandler = (s, e) => {
                Render(e.Graphics);
            };
            form.Paint += paintHandler;
            form.SetDoubleBuffered(true);
        }
    }
}