namespace PatternDepenInjectUnityWcf.Contract
{
    public interface IConfiguration
    {
        bool EnableLogs { get; set; }
        string Schema { get; set; }
        string Xslt { get; set; }
    }
}