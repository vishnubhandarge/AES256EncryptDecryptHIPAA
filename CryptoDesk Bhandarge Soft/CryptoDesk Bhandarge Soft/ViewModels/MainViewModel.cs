using CryptoDesk_Bhandarge_Soft.Services;
using System;
using System.ComponentModel;

namespace CryptoDesk_Bhandarge_Soft.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly SecurePayloadService _cryptoService = new();
    private bool _isDecryptMode;
    private string _inputText = "";
    private string _keyText = "";
    private string _ivText = "";
    private string _outputText = "";

    public string InputText
    {
        get => _inputText;
        set { _inputText = value; OnPropertyChanged(nameof(InputText)); }
    }

    public string KeyText
    {
        get => _keyText;
        set { _keyText = value; OnPropertyChanged(nameof(KeyText)); }
    }

    public string IVText
    {
        get => _ivText;
        set { _ivText = value; OnPropertyChanged(nameof(IVText)); }
    }

    public string OutputText
    {
        get => _outputText;
        set { _outputText = value; OnPropertyChanged(nameof(OutputText)); }
    }

    public void Encrypt()
    {
        try
        {
            OutputText = _cryptoService.Encrypt(InputText, KeyText, IVText);
        }
        catch (Exception ex)
        {
            OutputText = $"Error: {ex.Message}";
        }
    }

    public void Decrypt()
    {
        try
        {
            OutputText = _cryptoService.Decrypt(InputText, KeyText);
        }
        catch (Exception ex)
        {
            OutputText = $"Error: {ex.Message}";
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public bool IsDecryptMode
    {
        get => _isDecryptMode;
        set
        {
            if (_isDecryptMode != value)
            {
                _isDecryptMode = value;
                OnPropertyChanged(nameof(IsDecryptMode));
                OnPropertyChanged(nameof(ActionButtonText));
            }
        }
    }

    public bool IsEncryptMode => !IsDecryptMode;

    public string ActionButtonText
        => IsDecryptMode ? "Decrypt" : "Encrypt";
}
