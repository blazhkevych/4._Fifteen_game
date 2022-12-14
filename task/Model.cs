namespace task;

internal class Model : IModel
{
    // Array for storing button values.
    private readonly string[,] _arr =
    {
        { "1", "2", "3", "4" },
        { "5", "6", "7", "8" },
        { "9", "10", "11", "12" },
        { "13", "14", "15", "" }
    };

    // Indexer for accessing array elements.
    public string this[int i, int j]
    {
        get => _arr[i, j];
        set => _arr[i, j] = value;
    }

    // Game start time.
    public DateTime GameStartTime { get; set; }

    // Game stop time.
    public DateTime GameStopTime { get; set; }
}