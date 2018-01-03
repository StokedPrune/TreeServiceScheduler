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
    public class DetailsModel : PageModel
    {
        private readonly TreeServiceScheduler.Models.warehouseContext _context;

        public DetailsModel(TreeServiceScheduler.Models.warehouseContext context)
        {
            _context = context;
        }

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
    }
}
