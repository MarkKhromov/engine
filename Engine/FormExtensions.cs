using System.Reflection;
using System.Windows.Forms;

namespace Engine {
    static class FormExtensions {
        public static void SetDoubleBuffered(this Form form, bool value) {
            var property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            property.SetValue(form, value);
        }
    }
}