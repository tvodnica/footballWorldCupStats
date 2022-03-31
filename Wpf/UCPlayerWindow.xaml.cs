using System.Windows.Controls;
using System.Windows.Input;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for UCPlayerWindow.xaml
    /// </summary>
    public partial class UCPlayerWindow : UserControl
    {
        public UCPlayerWindow()
        {
            InitializeComponent();
            this.MouseDoubleClick += UCPlayerWindow_MouseDoubleClick;
        }

        private void UCPlayerWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Data.Files.SaveSelectedPlayerFile(this.text_Name.Text);
            PlayerWindow pw = new PlayerWindow();
            pw.ShowDialog();
        }
    }
}
