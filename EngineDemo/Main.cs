using System.Windows.Forms;
using Engine;

namespace EngineDemo {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
            new Game(this).Start();
        }
    }
}