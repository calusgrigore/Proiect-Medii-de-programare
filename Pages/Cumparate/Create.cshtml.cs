using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TelefoaneOnline.Data;
using TelefoaneOnline.Models;

namespace TelefoaneOnline.Pages.Cumparate
{
    public class CreateModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public CreateModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TelefonID"] = new SelectList(_context.Telefon, "ID", "ID");
        ViewData["UtilizatorID"] = new SelectList(_context.Set<Utilizator>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Cumparat Cumparat { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cumparat.Add(Cumparat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
