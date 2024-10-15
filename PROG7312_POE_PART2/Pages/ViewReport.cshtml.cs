using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG7312_POE_PART2.Models;
using static PROG7312_POE_PART2.Pages.ReportIssueModel;

namespace PROG7312_POE_PART2.Pages
{
    public class ViewReportModel : PageModel
    {
        public Dictionary<string, IssueReport> Reports { get; set; }

        public void OnGet()
        {
            Reports = ReportStorage.Reports;
        }
    }
}
