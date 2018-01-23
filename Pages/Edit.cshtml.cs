using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class EditModel : PageModel
    {

        private readonly AppDbContext _db;

        //constructor
        public EditModel(AppDbContext db)
        {
            _db = db;
        }
       

        [BindProperty]
        public Customer customer { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            customer = await _db.Customers.FindAsync(id);
            if( customer == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            // actualizar en la DB el usuario = estado modificado
            _db.Attach(customer).State = EntityState.Modified;
            //funcion try catch , envia un mensaje en caso de que se produzca una excepcion en un codigo
               try
                {
                await _db.SaveChangesAsync();
                }
             // en caso de que ocurra un error , enviar un mensaje de excepcion
             catch(DbUpdateConcurrencyException e)
               {
                throw new Exception($"Cliente {customer.Id} No Encontrado! ", e);
               }
            return RedirectToPage("/Index");
        }
    }
}