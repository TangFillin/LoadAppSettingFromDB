using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoadAppSettingFromDB.ConfigurationSet;
using Microsoft.Extensions.Configuration;

namespace LoadAppSettingFromDB.Controllers
{
    /// <summary>
    /// 更改配置，并刷新Configuration
    /// 参考：https://www.cnblogs.com/weihanli/p/reload-app-configuration-in-aspnetcore.html
    /// </summary>
    public class SystemConfigsController : Controller
    {
        private readonly ConfigurationsDbContext _context;
        private readonly IConfigurationRoot _configuration;

        public SystemConfigsController(ConfigurationsDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration as IConfigurationRoot;
        }

        // GET: SystemConfigs
        public async Task<IActionResult> Index()
        {
            return View(await _context.SystemConfigs.ToListAsync());
        }

        // GET: SystemConfigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemConfig = await _context.SystemConfigs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemConfig == null)
            {
                return NotFound();
            }

            return View(systemConfig);
        }

        // GET: SystemConfigs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SystemConfigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Key,Value,ValueType,DefValue,IsSystem")] SystemConfig systemConfig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemConfig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(systemConfig);
        }

        // GET: SystemConfigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemConfig = await _context.SystemConfigs.FindAsync(id);
            if (systemConfig == null)
            {
                return NotFound();
            }
            return View(systemConfig);
        }

        // POST: SystemConfigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Key,Value,ValueType,DefValue,IsSystem")] SystemConfig systemConfig)
        {
            if (id != systemConfig.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemConfig);
                    await _context.SaveChangesAsync();

                    //刷新Configuration（全局刷新了）
                    _configuration.Reload();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemConfigExists(systemConfig.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(systemConfig);
        }

        // GET: SystemConfigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemConfig = await _context.SystemConfigs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemConfig == null)
            {
                return NotFound();
            }

            return View(systemConfig);
        }

        // POST: SystemConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemConfig = await _context.SystemConfigs.FindAsync(id);
            _context.SystemConfigs.Remove(systemConfig);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemConfigExists(int id)
        {
            return _context.SystemConfigs.Any(e => e.Id == id);
        }
    }
}
