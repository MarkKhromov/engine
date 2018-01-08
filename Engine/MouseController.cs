using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Engine {
    public sealed class MouseController : IDisposable {
        public MouseController(Form form) {
            this.form = form;
            pressedButtons = new HashSet<MouseButtons>();
            PrepareForm();
        }

        readonly Form form;
        readonly HashSet<MouseButtons> pressedButtons;

        public PointF Coords { get; private set; }

        public bool IsPressed(MouseButtons button) {
            return pressedButtons.Contains(button);
        }

        void PrepareForm() {
            form.MouseMove += OnFormMouseMove;
            form.MouseDown += OnFormMouseDown;
            form.MouseUp += OnFormMouseUp;
        }

        void OnFormMouseUp(object sender, MouseEventArgs e) {
            pressedButtons.Remove(e.Button);
        }

        void OnFormMouseDown(object sender, MouseEventArgs e) {
            pressedButtons.Add(e.Button);
        }

        void OnFormMouseMove(object sender, MouseEventArgs e) {
            Coords = new PointF(e.X, e.Y);
        }

        void IDisposable.Dispose() {
            form.MouseMove -= OnFormMouseMove;
            form.MouseDown -= OnFormMouseDown;
            form.MouseUp -= OnFormMouseUp;
        }
    }
}