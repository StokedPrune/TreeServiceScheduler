using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TreeServiceScheduler.Models;

namespace TreeServiceScheduler.Pages.TreeSchedules
{
    public class CreateModel : PageModel
    {
        private readonly TreeServiceScheduler.Models.warehouseContext _context;

        public CreateModel(TreeServiceScheduler.Models.warehouseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TreeSchedule TreeSchedule { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TreeSchedule.Add(TreeSchedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}