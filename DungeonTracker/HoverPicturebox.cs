using System;
using System.Windows.Forms;

namespace DungeonTracker
{
    public partial class HoverPicturebox : PictureBox
    {
        public HoverPicturebox()
        {
            MouseEnter += HoverPicturebox_MouseEnter;
            MouseLeave += HoverPicturebox_MouseLeave;
        }

        private void HoverPicturebox_MouseEnter(object sender, EventArgs e)
        {
            SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void HoverPicturebox_MouseLeave(object sender, EventArgs e)
        {
            SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
