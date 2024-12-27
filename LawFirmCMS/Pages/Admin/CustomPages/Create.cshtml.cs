﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LawFirmCMS.Data;
using LawFirmCMS.Data.Models;

namespace LawFirmCMS.Pages.Admin.CustomPages
{
    public class CreateModel : PageModel
    {
        private readonly LawFirmCMS.Data.ApplicationDbContext _context;

        public CreateModel(LawFirmCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ParentId"] = new SelectList(_context.CustomPages, "Id", "Path");
            return Page();
        }

        [BindProperty]
        public CustomPage CustomPage { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (CustomPage.IsGroup == false)
                CustomPage.ParentId = null;

            _context.CustomPages.Add(CustomPage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
