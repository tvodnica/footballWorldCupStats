using System.Windows.Forms;

namespace WebForms
{
    public partial class UserControlPlayer : UserControl
    {
        public string Image { get; set; }
        public UserControlPlayer()
        {
            InitializeComponent();
            pictureBox_favStar.Visible = false;
        }
    }
}
