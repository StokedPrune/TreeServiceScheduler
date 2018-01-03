using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TreeServiceScheduler.Models;

namespace TreeServiceScheduler.Pages.TreeSchedules
{
    public class EditModel : PageModel
    {
        private readonly TreeServiceScheduler.Models.warehouseContext _context;

        public EditModel(TreeServiceScheduler.Models.warehouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TreeSchedule TreeSchedule { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TreeSchedule = await _context.TreeSchedule.FirstOrDefaultAsync(m => m.Id == id);

            if (TreeSchedule == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TreeSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreeScheduleExists(TreeSchedule.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TreeScheduleExists(int id)
        {
            return _context.TreeSchedule.Any(e => e.Id == id);
        }
    }
}
