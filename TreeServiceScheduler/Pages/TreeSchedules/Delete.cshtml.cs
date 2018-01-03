using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreeServiceScheduler.Models;

namespace TreeServiceScheduler.Pages.TreeSchedules
{
    public class DeleteModel : PageModel
    {
        private readonly TreeServiceScheduler.Models.warehouseContext _context;

        public DeleteModel(TreeServiceScheduler.Models.warehouseContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TreeSchedule = await _context.TreeSchedule.FindAsync(id);

            if (TreeSchedule != null)
            {
                _context.TreeSchedule.Remove(TreeSchedule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
