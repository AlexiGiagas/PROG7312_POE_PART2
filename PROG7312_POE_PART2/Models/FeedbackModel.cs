using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROG7312_POE_PART2.Models
{
    public class FeedbackModel
    {
        [Required(ErrorMessage = "Feedback is required.")]
        public string Feedback { get; set; }

        public int Rating { get; set; }

        public string SuccessMessage { get; set; }

        public static Dictionary<int, (string Feedback, int Rating)> FeedbackDictionary = new Dictionary<int, (string Feedback, int Rating)>();
        private static int _feedbackIdCounter = 1;

        public static void AddFeedback(string feedback, int rating)
        {
            FeedbackDictionary[_feedbackIdCounter++] = (feedback, rating);
        }
    }
}
