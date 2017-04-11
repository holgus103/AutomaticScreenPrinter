namespace AutomaticScreenPrinterGui
{
    public interface IApplicationInterface
    {
        string FilePath { get; set; }
        int Interval { get; set; }
        bool Status { get; }
        void Stop();
        void Execute();
    }
}
