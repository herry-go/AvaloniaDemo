using Avalonia.Controls.ApplicationLifetimes;

namespace SukiDemo.Services
{
    public class ClipboardService(IClassicDesktopStyleApplicationLifetime liftime)
    {
        public void CopyToClipboard(string text) => liftime.MainWindow?.Clipboard?.SetTextAsync(text);
    }
}