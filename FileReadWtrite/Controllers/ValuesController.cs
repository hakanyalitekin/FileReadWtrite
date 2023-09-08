using FileReadWtrite.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileReadWtrite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ValuesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // PDF dosyasını veritabanına ekleme
        [HttpPost]
        public async Task<IActionResult> AddPdf(IFormFile file)
        {
            try
            {
                byte[] fileBytes = null;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();

                }
                var pdfFile = new FileStore
                {
                    FileName = "example.pdf", // PDF dosyasının adını ayarlayın
                    FileContent = fileBytes, // İstek gövdesinden binary veriyi okuyun
                };

                _dbContext.PdfFiles.Add(pdfFile);
                _dbContext.SaveChanges();

                return Ok("PDF dosyası başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }

        // PDF dosyasını veritabanından okuma
        [HttpGet("{fileName}")]
        public IActionResult GetPdf(string fileName)
        {
            try
            {
                var pdfFile = _dbContext.PdfFiles.FirstOrDefault(p => p.FileName == fileName);

                if (pdfFile != null)
                {
                    return File(pdfFile.FileContent, "application/pdf");
                }
                else
                {
                    return NotFound("PDF dosyası bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Hata: {ex.Message}");
            }
        }
    }
}