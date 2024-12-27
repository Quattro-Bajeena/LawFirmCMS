﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;

namespace LawFirmCMS.Pages.Admin.CustomPages
{
    public class EditModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public EditModel(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomPage CustomPage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custompage =  await _context.CustomPages.FirstOrDefaultAsync(m => m.Id == id);
            if (custompage == null)
            {
                return NotFound();
            }
            CustomPage = custompage;
           ViewData["ParentId"] = new SelectList(_context.CustomPages, "Id", "Path");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomPageExists(CustomPage.Id))
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

        private bool CustomPageExists(int id)
        {
            return _context.CustomPages.Any(e => e.Id == id);
        }
    }
}
