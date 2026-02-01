using System.Text;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using Workout.Views;

namespace Workout;

public partial class AppShell : Shell
{
    private readonly IFileSaver fileSaver;
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(WorkoutPage), typeof(WorkoutPage));
        Routing.RegisterRoute(nameof(ExercisePage), typeof(ExercisePage));
        Routing.RegisterRoute(nameof(ExerciseDetailPage), typeof(ExerciseDetailPage));
    }

    private async void OnImportClicked(object sender, EventArgs e)
    {
        try
        {
            var pickResult = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Datenbank importieren",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.Android, new[] { "application/octet-stream" } },
                    { DevicePlatform.iOS, new[] { "public.data" } },
                    { DevicePlatform.WinUI, new[] { ".db", ".db3" } }
                })
            });

            if (pickResult == null)
                return;

            // 1. DB schließen
            // await Database.CloseAsync();

            // 2. Backup erstellen
            if (File.Exists(Constants.DatabasePath))
            {
                var backupPath = Constants.DatabasePath + ".bak";

                if (File.Exists(backupPath))
                    File.Delete(backupPath);

                File.Copy(Constants.DatabasePath, backupPath);
                File.Delete(Constants.DatabasePath);
            }

            // 3. Neue DB kopieren
            await using var sourceStream = await pickResult.OpenReadAsync();
            await using var targetStream = File.Create(Constants.DatabasePath);

            await sourceStream.CopyToAsync(targetStream);

            await DisplayAlert("Import", "Import erfolgreich. App neu starten.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Import fehlgeschlagen", ex.Message, "OK");
        }
    }



    private async void OnExportClicked(object sender, EventArgs e)
    {
        try
        {
            // Falls du irgendwo eine offene SQLite-Verbindung hast:
            // await Database.CloseAsync();

            if (!File.Exists(Constants.DatabasePath))
            {
                await DisplayAlert("Export", "Datenbank nicht gefunden.", "OK");
                return;
            }

            await using var stream = File.OpenRead(Constants.DatabasePath);

            var result = await FileSaver.Default.SaveAsync(
                "WorkoutSQLite_backup.db3",
                stream,
                CancellationToken.None);

            if (result.IsSuccessful)
            {
                await Toast
                    .Make($"Export erfolgreich:\n{result.FilePath}")
                    .Show();
            }
            else
            {
                await DisplayAlert(
                    "Export fehlgeschlagen",
                    result.Exception?.Message ?? "Unbekannter Fehler",
                    "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fehler", ex.Message, "OK");
        }
    }

}