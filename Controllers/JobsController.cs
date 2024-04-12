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
    public class JobsController : Controller
    {
        public readonly EmpleoContext _context;
        private readonly HelperUploadFiles helperUploadFiles;

        public JobsController(EmpleoContext context, HelperUploadFiles helperUpload)
        {
            _context = context;
            this.helperUploadFiles = helperUpload;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Jobs.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View(await _context.Jobs.FindAsync(id));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View(await _context.Jobs.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Job job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Job job)
        {
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Job job, IFormFile file)
        {
            string nameFile = file.FileName;
            string pathFile = await this.helperUploadFiles.UploadFilesAsync(file, nameFile, Folders.Uploads);

            job.LogoCompany = nameFile;
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Search(string search)
        {
            var jobs = _context.Jobs.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                jobs = jobs.Where(m => m.NameCompany.Contains(search) || m.OfferTitle.Contains(search) || m.Description.Contains(search) || m.Country.Contains(search) || m.Languages.Contains(search));
            }

            return View("Index", jobs.ToList());
        }
    }
}
