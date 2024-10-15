using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG7312_POE_PART2.Pages
{
    public class LocalEventsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public SortedDictionary<int, Event> Events { get; set; } = new SortedDictionary<int, Event>();
        public SortedDictionary<int, Event> RecommendedEvents { get; set; } = new SortedDictionary<int, Event>();
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            Events = GetUpcomingEvents();
        }

        public IActionResult OnPostSearch()
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                ErrorMessage = "Please enter a search term.";
                Events = GetUpcomingEvents();
                return Page();
            }

            // Perform search
            Events = GetUpcomingEvents()
                .Where(e => e.Value.Category.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                            e.Value.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                            e.Value.Date.ToString("dd/MM/yyyy").Contains(SearchTerm))
                .ToSortedDictionary();

            // Generate recommendations based on user search
            RecommendedEvents = GetRecommendedEvents(SearchTerm);

            return Page();
        }

        private SortedDictionary<int, Event> GetUpcomingEvents()
        {
            var events = new SortedDictionary<int, Event>
            {
                { 1, new Event { Title = "Community Cleanup", Date = DateTime.Now.AddDays(7), Category = "Environment", Description = "Join us for a community get together as we clean our streets." }},
                { 2, new Event { Title = "Local Art Fair", Date = DateTime.Now.AddDays(14), Category = "Art", Description = "Explore local artists and beautiful art pieces." }},
                { 3, new Event { Title = "Health Awareness Workshop", Date = DateTime.Now.AddDays(30), Category = "Health", Description = "Learn about health and wellness." }},
                { 4, new Event { Title = "Tree Planting", Date = DateTime.Now.AddDays(10), Category = "Environment", Description = "Join us for a community get together." }},
                { 5, new Event { Title = "Yoga in the Park", Date = DateTime.Now.AddDays(5), Category = "Health", Description = "Join us for a community get together for some yoga." }},
                { 6, new Event { Title = "Street Music Festival", Date = DateTime.Now.AddDays(20), Category = "Music", Description = "Join us for a community get together for the art of music." }},
            };

            return events;
        }

        // Recommendation logic based on the user's search term
        private SortedDictionary<int, Event> GetRecommendedEvents(string searchTerm)
        {
            var allEvents = GetUpcomingEvents();

            // Find the categories of the events the user searched for
            var searchedCategories = allEvents
                .Where(e => e.Value.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            e.Value.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .Select(e => e.Value.Category)
                .Distinct()
                .ToList();

            // Recommend events that belong to other categories (not the searched categories)
            var recommendedEvents = allEvents
                .Where(e => !searchedCategories.Contains(e.Value.Category)) // Exclude searched categories
                .Where(e => e.Value.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            e.Value.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) // Match by title or description
                .ToSortedDictionary();

            return recommendedEvents;
        }
    }

    public class Event
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }

    public static class Extensions
    {
        public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            var dictionary = new SortedDictionary<TKey, TValue>();
            foreach (var kvp in source)
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }
            return dictionary;
        }
    }
}
