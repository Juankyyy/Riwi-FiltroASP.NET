using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empleo.Data;
using Empleo.Models;

using Empleo.Helpers;
using Empleo.Providers;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Empleo.Controllers
{
    public class EmployeesController : Controller
    {
        public readonly EmpleoContext _context;
        private readonly HelperUploadFiles helperUploadFiles;

        public EmployeesController(EmpleoContext context, HelperUploadFiles helperUpload)
        {
            _context = context;
            this.helperUploadFiles = helperUpload;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View(await _context.Employees.FindAsync(id));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View(await _context.Employees.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee, IFormFile fileImage, IFormFile fileCv)
        {
            string nameFileImage = fileImage.FileName;
            string nameFileCv = fileCv.FileName;

            string pathFile = await this.helperUploadFiles.UploadFilesAsync(fileImage, nameFileImage, Folders.Uploads);

            employee.ProfilePicture = nameFileImage;
            employee.Cv = nameFileCv;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Search(string search)
        {
            var employees = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                employees = employees.Where(m => m.Names.Contains(search) || m.LastNames.Contains(search) || m.Email.Contains(search) || m.About.Contains(search));
            }

            return View("Index", employees.ToList());
        }
    }
}