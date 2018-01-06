using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Engine {
    public sealed class KeyboardManager : IDisposable {
        public KeyboardManager(Form form) {
            this.form = form;
            pressedKeys = new HashSet<Keys>();
            PrepareForm();
        }

        readonly Form form;
        readonly HashSet<Keys> pressedKeys;

        public bool IsPressed(Keys key) {
            return pressedKeys.Contains(key);
        }

        void PrepareForm() {
            form.KeyDown += OnFormKeyDown;
            form.KeyUp += OnFormKeyUp;
        }

        void OnFormKeyUp(object sender, KeyEventArgs e) {
            pressedKeys.Remove(e.KeyCode);
        }

        void OnFormKeyDown(object sender, KeyEventArgs e) {
            pressedKeys.Add(e.KeyCode);
        }

        void IDisposable.Dispose() {
            form.KeyDown -= OnFormKeyDown;
            form.KeyUp -= OnFormKeyUp;
        }
    }
}