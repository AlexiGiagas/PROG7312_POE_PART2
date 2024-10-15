using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace PROG7312_POE_PART2.Pages
{
    public class FeedbackModel : PageModel
    {
        [BindProperty]
        public string Feedback { get; set; }

        [BindProperty]
        public int Rating { get; set; }

        public string SuccessMessage { get; set; }

        public static Dictionary<int, (string Feedback, int Rating)> FeedbackDictionary = new Dictionary<int, (string Feedback, int Rating)>();
        private static int _feedbackIdCounter = 1;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            FeedbackDictionary[_feedbackIdCounter++] = (Feedback, Rating);

            SuccessMessage = "Thank you for your feedback!";
            Feedback = string.Empty;
            Rating = 0;

            return Page();
        }
    }
}
