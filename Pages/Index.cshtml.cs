using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        //constructor
        public IndexModel (AppDbContext db)
        {
            _db = db;
        }
        //crear una lista de clientes 
        public IList<Customer> Customers { get; private set; }

        [TempData]
        public string Message { get; set; }

        //mostrar lista de clientes funcion asincrona 
        public async Task OnGetAsync()
        {
            Customers = await _db.Customers.AsNoTracking().ToListAsync(); 

        }
        //eliminar un cliente de la database funcion asincrona (recibe el valor de id)
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            //variable que usa el id , espera que busque en la base de datos el id 
            var customer = await _db.Customers.FindAsync(id);
            //si existe el cliente buscado , se elimina de la base de datos 
            if (customer != null)
            {
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
                Message = $" Cliente {customer.Name} Eliminado.";
                //se espera que se guarden los cambios
            }
            return RedirectToPage();
        }
    }
}
