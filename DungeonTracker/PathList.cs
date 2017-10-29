using System.Windows.Forms;

namespace DungeonTracker
{
    public partial class PathList : UserControl
    {
        public PathList()
        {
            InitializeComponent();
        }

        public Label P1
        {
            get { return label1; }
            set { label1 = value; }
        }

        public Label P2
        {
            get { return label2; }
            set { label2 = value; }
        }

        public Label P3
        {
            get { return label3; }
            set { label3 = value; }
        }

        public Label P4
        {
            get { return label4; }
            set { label4 = value; }
        }
    }
}
