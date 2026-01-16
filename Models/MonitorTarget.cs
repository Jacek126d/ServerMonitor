namespace ServerMonitor.Models;

public class MonitorTarget
{
    public int Id { get; set; }

 
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    public bool IsOnline { get; set; }
    public int ResponseTimeMs { get; set; }
    public string? ServerLocation { get; set; } 
    public DateTime LastChecked { get; set; }
}