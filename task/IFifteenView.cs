namespace task;

public interface IFifteenView
{
    // Indexer for accessing array elements.
    public string this[int i, int j] { get; set; }

    // User move button name.
    string UserMoveButtonName { get; set; }

    // Event of pressing the "New Game" button.
    event EventHandler<EventArgs> NewGameButtonClickEvent;

    // Event of pressing a button on the game field.
    event EventHandler<EventArgs>? GameFieldButtonClickEvent;

    // Displaying a message about the victory.
    void WinMessage(TimeSpan timeSpan);
}