using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class CreateModel : PageModel
    {
      
        private readonly AppDbContext _db;

        //constructor
        public CreateModel (AppDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }

        //propiedad
        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            Message = $" Cliente {Customer.Name}  Agregado";
            return RedirectToPage("/Index");
        }

    }
}
