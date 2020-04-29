using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Database_Api;

namespace Checkpoint_WCircus
{
    /// <summary>
    /// Interaction logic for UserControlFeedback.xaml
    /// </summary>
    public partial class UserControlFeedback : UserControl
    {
        private DbPopulator dbPopulator;
        public UserControlFeedback()
        {
            InitializeComponent();
            dbPopulator = new DbPopulator();
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            Feedback feedback = new Feedback();
            feedback.Name = txtName.Text;
            feedback.Phone = txtPhone.Text;
            feedback.Email = txtEmail.Text;
            feedback.Email = txtEmail.Text;
            feedback.Comment = txtComment.Text;
            dbPopulator.SaveFeedback(feedback);
            Reset();
        }

        private void Reset()
        {
            txtName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtComment.Text = String.Empty;
            MessageBox.Show("Thanks bro!");
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            //Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            //e.Handled = true;
        }
    }
}
