using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Threading.Tasks;

namespace ThreeButtonDialog;

public partial class ThreeButtonDialogView : Window
{
    public static async Task<ThreeButtonResult> ShowAsync(ThreeButtonDialogConfig config, Window? owner = null)
    {
        owner ??= (Avalonia.Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
        if (owner == null) return ThreeButtonResult.Button1;
        return await new ThreeButtonDialogView(config).ShowDialog<ThreeButtonResult>(owner);
    }

    private readonly ThreeButtonResult _button1Result;
    private readonly ThreeButtonResult _button2Result;
    private readonly ThreeButtonResult _button3Result;

    public ThreeButtonDialogView() : this(new ThreeButtonDialogConfig()) { }

    public ThreeButtonDialogView(ThreeButtonDialogConfig config)
    {
        InitializeComponent();

        _button1Result = config.Button1Result;
        _button2Result = config.Button2Result;
        _button3Result = config.Button3Result;

        Title = config.Title;
        MessageText.Text = config.Message;

        if (!string.IsNullOrEmpty(config.DetailMessage))
        {
            DetailText.Text = config.DetailMessage;
            DetailText.IsVisible = true;
        }

        ApplyIconTheme(config.IconTheme);

        SetButton(Button1, config.Button1Text);
        SetButton(Button2, config.Button2Text);
        SetButton(Button3, config.Button3Text);
    }

    private static void SetButton(Button button, string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            button.Content = text;
            button.IsVisible = true;
        }
        else
        {
            button.IsVisible = false;
        }
    }

    private void ApplyIconTheme(DialogIconTheme theme)
    {
        string assetPath = theme switch
        {
            DialogIconTheme.Warning => "avares://ThreeButtonDialog/Assets/Icons/warning-triangle.png",
            DialogIconTheme.Info    => "avares://ThreeButtonDialog/Assets/Icons/info-circle.png",
            DialogIconTheme.Error   => "avares://ThreeButtonDialog/Assets/Icons/error-circle.png",
            _                       => "avares://ThreeButtonDialog/Assets/Icons/question-circle.png"
        };

        IconDisplay.Source = new Bitmap(AssetLoader.Open(new Uri(assetPath)));
    }

    private void Button1_Click(object? sender, RoutedEventArgs e) => Close(_button1Result);
    private void Button2_Click(object? sender, RoutedEventArgs e) => Close(_button2Result);
    private void Button3_Click(object? sender, RoutedEventArgs e) => Close(_button3Result);
}
