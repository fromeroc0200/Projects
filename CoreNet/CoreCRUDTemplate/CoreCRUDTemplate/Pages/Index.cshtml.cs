using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCRUDTemplate.Pages
{
    public class IndexModel : PageModel
    {
        private AppDbContext _db;

        public IndexModel(AppDbContext db) { _db = db; }

        public IList<Customer> Customers { get; private set; }

        //--Tiene el mismo nombre que la variable de la pagina Create y 
        //tiene el atributo TempData que obtiene el valor y lo muestra en la pagina index
        [TempData]
        public string Message { get; set; }

        public async Task OnGetAsync()
        {
            Customers = await _db.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var costumer = await _db.Customers.FindAsync(id);
            if (costumer != null)
            {
                _db.Customers.Remove(costumer);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();

        }
    }
}
