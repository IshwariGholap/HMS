//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using HospitalManagementSystem.Data;
//using HospitalManagementSystem.Models;

//public class DoctorsController : Controller
//{
//    private readonly ApplicationDbContext _context;

//    public DoctorsController(ApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<IActionResult> Index()
//    {
//        return View(await _context.Doctors.ToListAsync());
//    }

//    public IActionResult Create()
//    {
//        return View();
//    }

//    [HttpPost]
//   // [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create([Bind("Id,Name,Specialization")] Doctor doctor)
//    {

//        foreach (var modelStateEntry in ModelState.Values)
//        {
//            foreach (var error in modelStateEntry.Errors)
//            {
//                Console.WriteLine($"Error: {error.ErrorMessage}");
//            }
//        }

//        if (ModelState.IsValid)
//        {
//            _context.Add(doctor);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }
//        return View(doctor);
//    }


//}


using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

public class DoctorsController : Controller
{
    private readonly ApplicationDbContext _context;

    public DoctorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Doctors
    public async Task<IActionResult> Index()
    {
        return View(await _context.Doctors.ToListAsync());
    }

    // GET: Doctors/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Doctors/Create
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Specialization")] Doctor doctor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(doctor);
    }

    // GET: Doctors/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var doctor = await _context.Doctors.FindAsync(id);

        if (doctor == null)
        {
            return NotFound();
        }

        return View(doctor);
    }

    // POST: Doctors/Edit/5
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Specialization")] Doctor doctor)
    {
        if (id != doctor.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(doctor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(doctor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(doctor);
    }

    // GET: Doctors/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var doctor = await _context.Doctors
            .FirstOrDefaultAsync(m => m.Id == id);

        if (doctor == null)
        {
            return NotFound();
        }

        return View(doctor);
    }

    // POST: Doctors/DeleteConfirmed/5
    [HttpPost, ActionName("DeleteConfirmed")]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null)
        {
            return NotFound();
        }

        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DoctorExists(int id)
    {
        return _context.Doctors.Any(e => e.Id == id);
    }

    // GET: Doctors/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var doctor = await _context.Doctors
            .FirstOrDefaultAsync(m => m.Id == id);

        if (doctor == null)
        {
            return NotFound();
        }

        return View(doctor);
    }

}
