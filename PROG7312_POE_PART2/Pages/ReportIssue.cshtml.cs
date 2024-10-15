using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PROG7312_POE_PART2.Models;

namespace PROG7312_POE_PART2.Pages
{
    public class ReportIssueModel : PageModel
    {
        [BindProperty, Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [BindProperty, Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [BindProperty, Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [BindProperty]
        public IFormFile Media { get; set; }

        public string SuccessMessage { get; set; }

        public static class ReportStorage
        {
            public static Dictionary<string, IssueReport> Reports { get; set; } = new Dictionary<string, IssueReport>();

            public static Dictionary<string, int> DailyReportCount { get; set; } = new Dictionary<string, int>();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            if (Media != null)
            {
                var filePath = Path.Combine(uploadsFolder, Media.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Media.CopyToAsync(fileStream);
                }
            }

            var report = new IssueReport
            {
                Location = Location,
                Category = Category,
                Description = Description,
                MediaFileName = Media?.FileName,
                SubmissionDate = DateTime.Now
            };

            var dateKey = DateTime.Now.ToString("ddMMyyyy");
            if (!ReportStorage.DailyReportCount.ContainsKey(dateKey))
            {
                ReportStorage.DailyReportCount[dateKey] = 0;
            }

            ReportStorage.DailyReportCount[dateKey]++;
            var reportId = $"{dateKey}-{ReportStorage.DailyReportCount[dateKey]:D4}";

            ReportStorage.Reports[reportId] = report;
            SuccessMessage = "Thank you for your submission!";
            Location = string.Empty;
            Category = string.Empty;
            Description = string.Empty;
            Media = null;

            return Page();
        }
    }
}
