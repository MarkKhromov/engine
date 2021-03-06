﻿using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Engine {
    public class Game {
        public Game(Form form) {
            this.form = form;
            IsRunning = false;
            KeyboardManager = new KeyboardManager(form);
            MouseController = new MouseController(form);
            Player = new Player(this);
            Grid = new Grid(this);
            Bullets = new Collection<Bullet>();
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
        public MouseController MouseController { get; }

        public bool IsRunning { get; private set; }
        public Player Player { get; }
        public Grid Grid { get; }
        // TODO: Refactoring
        public Collection<Bullet> Bullets { get; }
        public SizeF WindowSize => form.Size;

        public void Start() {
            thread.Start();
        }

        public void Stop() {
            IsRunning = false;
            thread.Join();
        }

        void Tick() {
            Player.Tick();
            Grid.Tick();
            foreach(var bullet in Bullets) {
                bullet.Tick();
            }
        }

        void Render(Graphics graphics) {
            graphics.Clear(Color.Black);
            Player.Render(graphics);
            Grid.Render(graphics);
            foreach(var bullet in Bullets) {
                bullet.Render(graphics);
            }
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