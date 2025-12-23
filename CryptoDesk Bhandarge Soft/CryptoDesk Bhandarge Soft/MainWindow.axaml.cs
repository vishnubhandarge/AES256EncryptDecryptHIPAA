using Avalonia.Controls;
using Avalonia.Interactivity;
using CryptoDesk_Bhandarge_Soft.ViewModels;

namespace CryptoDesk_Bhandarge_Soft
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Action_Click(object? sender, RoutedEventArgs e)
        {
            if (DataContext is not MainViewModel vm)
                return;

            if (vm.IsEncryptMode)
                vm.Encrypt();
            else
                vm.Decrypt();
        }

        private void Encrypt_Click(object? sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel)?.Encrypt();
        }

        private void Decrypt_Click(object? sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel)?.Decrypt();
        }

    }
}