namespace task;

internal static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var form = new Form1();
        IModel model = new Model();
        var presenter = new FifteenPresenter(model, form);

        Application.Run(form);
    }
}