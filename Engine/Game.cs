using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Engine {
    public class Game {
        public Game(Form form) {
            this.form = form;
            IsRunning = false;
            KeyboardManager = new KeyboardManager(form);
            Player = new Player(this);
            thread = new Thread(new ThreadStart(() => {
                PrepareForm();
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
        }

        readonly Form form;
        readonly Thread thread;

        public KeyboardManager KeyboardManager { get; }

        public bool IsRunning { get; private set; }
        public Player Player { get; }

        public void Start() {
            thread.Start();
        }

        public void Stop() {
            IsRunning = false;
            thread.Join();
        }

        void Tick() {
            Player.Tick();
        }

        void Render(Graphics graphics) {
            graphics.Clear(Color.Black);
            Player.Render(graphics);
            DebugHelper.RenderCoords(graphics, Player);
        }

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