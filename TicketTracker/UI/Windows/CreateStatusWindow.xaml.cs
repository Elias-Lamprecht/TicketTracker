using System.Windows;
using TicketTracker.Services;

namespace TicketTracker.UI.Forms
{
    /// <summary>
    /// Interaction logic for CreateStatusWindow.xaml
    /// </summary>
    public partial class CreateStatusWindow : Window
    {
        public CreateStatusWindow()
        {
            InitializeComponent();
        }

        private void CreateStatus_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleInput.Text))
            {
                MessageBox.Show("The Title can't be empty or just whitespace.", "ValidationError", MessageBoxButton.OK, MessageBoxImage.Warning);
                TitleInput.Focus();
                return;
            }

            if (TitleInput.Text.Length > 32)
            {
                MessageBox.Show($"The Title can't be longer than 32 Characters. (Currently {TitleInput.Text.Length} long)", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                TitleInput.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(DescriptionInput.Text))
            {
                MessageBox.Show("The Description can't be empty or just whitespace.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                DescriptionInput.Focus();
                return;
            }

            if (DescriptionInput.Text.Length > 128)
            {
                MessageBox.Show($"The Description can't be longer than 128 Characters. (Currently {DescriptionInput.Text.Length} long)", "ValidationError", MessageBoxButton.OK, MessageBoxImage.Warning);
                DescriptionInput.Focus();
                return;
            }

            StatusService.Instance().CreateStatus(Guid.NewGuid(), TitleInput.Text, DescriptionInput.Text);
        }
    }
}
