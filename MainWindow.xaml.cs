using System.Windows;
using TicketTracker.UI.Forms;

namespace TicketTracker.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CreateStatusButton_Click(object sender, RoutedEventArgs e)
    {
        CreateStatusWindow createStatusWindow = new CreateStatusWindow();
        createStatusWindow.Owner = this;
        createStatusWindow.ShowDialog();
    }
}