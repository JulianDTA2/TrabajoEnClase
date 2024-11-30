namespace TrabajoEnClase.Views;

public partial class AllNotesPageJT : ContentPage
{
    public AllNotesPageJT()
    {
        InitializeComponent();

        BindingContext = new Models.AllNotesPageJT();
    }

    protected override void OnAppearing()
    {
        ((Models.AllNotesPageJT)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePageJT));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Note)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(NotePageJT)}?{nameof(NotePageJT.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}