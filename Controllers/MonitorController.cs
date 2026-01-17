using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerMonitor.Data;
using ServerMonitor.Services;

namespace ServerMonitor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MonitorController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly MonitorService _monitorService;

    public MonitorController(AppDbContext context, MonitorService monitorService)
    {
        _context = context;
        _monitorService = monitorService;
    }
    [HttpGet]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTarget(int id)
    {
        var target = await _context.Targets.FindAsync(id); 
        if (target == null)
        {
            return NotFound();
        }
        return Ok(target);
    }
    [HttpPost]
    public async Task<IActionResult> AddTarget([FromBody] Models.MonitorTarget target)
    {
        target.LastChecked = DateTime.MinValue;
        _context.Targets.Add(target);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTarget), new { id = target.Id }, target);
    }
}