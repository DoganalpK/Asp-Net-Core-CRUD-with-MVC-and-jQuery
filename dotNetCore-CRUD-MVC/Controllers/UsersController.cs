using dotNetCore_CRUD_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static dotNetCore_CRUD_MVC.Helper;

namespace dotNetCore_CRUD_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/AddOrEdit?id   => Insert
        // GET: Users/AddOrEdit?id=5 => Update
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id)
        {
            if (id == 0)
            {
                return PartialView(new UsersModel());
            }
            else
            {
                var userModel = await _context.Users.FindAsync(id);
                if (userModel == null)
                    return NotFound();

                return PartialView(userModel);
            }
        }

        // POST: Users/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, UsersModel model)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Users.Add(model);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Users.Update(model);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        return NotFound();
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Users.ToList()) });

            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        // POST: Users/AddOrEdit/id?
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var model = await _context.Users.FindAsync(id);
            _context.Users.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Users.ToList()) });
        }
    }
}
