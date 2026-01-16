using System.Diagnostics;
using System.Net.Http.Json;
using ServerMonitor.Data;

namespace ServerMonitor.Services;

public class MonitorService
{
    private readonly AppDbContext _context;
    private readonly HttpClient _httpClient;

    public MonitorService(AppDbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task CheckTargetsAsync()
    {
        var targets = _context.Targets.ToList();

        foreach (var target in targets)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, target.Url);
                request.Headers.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
                var response = await _httpClient.SendAsync(request);
                stopwatch.Stop();
                target.IsOnline = true;
                target.ResponseTimeMs = (int)stopwatch.ElapsedMilliseconds;

                if (string.IsNullOrEmpty(target.ServerLocation) && target.IsOnline)
                {
                    var host = new Uri(target.Url).Host;

                    //  ip-api.com
                    var geoData = await _httpClient.GetFromJsonAsync<GeoResponse>($"http://ip-api.com/json/{host}");
                    target.ServerLocation = $"{geoData?.country}, {geoData?.isp}";
                }
            }
            catch
            {
                target.IsOnline = false;
                target.ResponseTimeMs = 0;
            }
            target.LastChecked = DateTime.Now;
        }

        await _context.SaveChangesAsync();
    }
}

public record GeoResponse(string country, string isp);