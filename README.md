# ThreeButtonDialog


A reusable Avalonia dialog library with up to three configurable buttons and four icon themes.

<img width="1131" height="386" alt="image" src="https://github.com/user-attachments/assets/38bb72c0-aa54-439a-a91b-1ef470124786" />


I use this extensively in my Gamelist Manager application.  I included the button style which you may wish to use for other buttons as well to give them different colors and a nicer appearance.


## Usage

Reference the project or DLL, then call the static `ShowAsync`:

```csharp
var result = await ThreeButtonDialogView.ShowAsync(new ThreeButtonDialogConfig
{
    Title        = "Delete File",
    Message      = "Are you sure you want to delete this file?",
    DetailMessage = "This action cannot be undone.",
    IconTheme    = DialogIconTheme.Warning,
    Button1Text  = "Cancel",   Button1Result = ThreeButtonResult.Button1,
    Button2Text  = "No",       Button2Result = ThreeButtonResult.Button2,
    Button3Text  = "Yes",      Button3Result = ThreeButtonResult.Button3,
}, ownerWindow);

if (result == ThreeButtonResult.Button3)
    DeleteFile();
```

## Icon themes

| `DialogIconTheme` | Icon                     |
|-------------------|--------------------------|
| `Question`        | question-circle.png      |
| `Info`            | info-circle.png          |
| `Warning`         | warning-triangle.png     |
| `Error`           | error-circle.png         |

## Button visibility

Set any `ButtonNText` to `null` or empty to hide that button entirely.
A one-button OK dialog:

```csharp
new ThreeButtonDialogConfig
{
    Message      = "Operation complete.",
    IconTheme    = DialogIconTheme.Info,
    Button1Text  = "OK",
    Button2Text  = "",
    Button3Text  = "",
}
```

## Button styles

Buttons use the `rounded` + colour classes from `ButtonStyle.axaml`.
Available colours: `grey` `green` `yellow` `red` `blue` `orange` `purple`
`teal` `pink` `brown` `cyan` `lime`

The default layout is Button1=grey, Button2=yellow, Button3=green.
