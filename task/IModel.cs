namespace task;

public interface IModel
{
    // Indexer for accessing array elements.
    string this[int i, int j] { get; set; }

    // Game start time.
    DateTime GameStartTime { get; set; }

    // Game stop time.
    DateTime GameStopTime { get; set; }
}