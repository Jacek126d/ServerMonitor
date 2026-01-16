using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerMonitor.Data;
using ServerMonitor.Models;
using ServerMonitor.Services;

namespace ServerMonitor.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly MonitorService _monitorService;

    public HomeController(AppDbContext context, MonitorService monitorService)
    {
        _context = context;
        _monitorService = monitorService;
    }

    public async Task<IActionResult> Index()
    {
        // odswiezanie
        await _monitorService.CheckTargetsAsync();
        //zaciaganie z bazy
        var targets = await _context.Targets.ToListAsync();

        // widok 
        return View(targets);
    }

    [HttpPost]
    public async Task<IActionResult> Add(MonitorTarget target)
    {
        // Prosta walidacja i dodanie do bazy
        target.LastChecked = DateTime.MinValue;
        _context.Targets.Add(target);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var target = await _context.Targets.FindAsync(id);
        if (target != null)
        {
            _context.Targets.Remove(target);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}