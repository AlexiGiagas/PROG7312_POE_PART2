using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PROG7312_POE_PART2.Pages
{
    public class ServiceRequestModel : PageModel
    {
        public List<ServiceRequest> Requests { get; set; } = new List<ServiceRequest>();

        public void OnGet()
        {
            Requests = GetRequests();
        }

        private List<ServiceRequest> GetRequests()
        {
            var bst = new ServiceRequestBST();
            bst.Insert(new ServiceRequest
            {
                ID = 1,
                Title = "Streetlight Malfunction",
                Status = "In Progress",
                SubmissionDate = DateTime.Now.AddDays(-7),
                Description = "Streetlight at Main Road intersection is flickering.",
                Category = "Utilities",
                Location = "Main Road, Sector 5"
            });

            bst.Insert(new ServiceRequest
            {
                ID = 2,
                Title = "Water Leakage",
                Status = "Completed",
                SubmissionDate = DateTime.Now.AddDays(-15),
                Description = "Pipe burst causing water pooling near the park.",
                Category = "Utilities",
                Location = "Green Park, Block B"
            });

            bst.Insert(new ServiceRequest
            {
                ID = 3,
                Title = "Pothole Repair Request",
                Status = "Pending",
                SubmissionDate = DateTime.Now.AddDays(-3),
                Description = "Large pothole causing traffic delays.",
                Category = "Roads",
                Location = "4th Avenue and Birch Street Intersection"
            });

            bst.Insert(new ServiceRequest
            {
                ID = 4,
                Title = "Garbage Collection Delay",
                Status = "In Progress",
                SubmissionDate = DateTime.Now.AddDays(-5),
                Description = "Garbage has not been collected for two weeks.",
                Category = "Sanitation",
                Location = "Sunset Boulevard, Lane 3"
            });

            bst.Insert(new ServiceRequest
            {
                ID = 5,
                Title = "Broken Traffic Light",
                Status = "Pending",
                SubmissionDate = DateTime.Now.AddDays(-2),
                Description = "Traffic light not functioning during peak hours.",
                Category = "Utilities",
                Location = "Maple Street and Oak Drive"
            });

            bst.Insert(new ServiceRequest
            {
                ID = 6,
                Title = "Blocked Drain",
                Status = "Completed",
                SubmissionDate = DateTime.Now.AddDays(-12),
                Description = "Drain is blocked causing water stagnation.",
                Category = "Sanitation",
                Location = "Hillside Road, Plot 22"
            });

            bst.Insert(new ServiceRequest
            {
                ID = 7,
                Title = "Overgrown Trees",
                Status = "In Progress",
                SubmissionDate = DateTime.Now.AddDays(-8),
                Description = "Trees obstructing power lines, need trimming.",
                Category = "Utilities",
                Location = "Forest Avenue, Block C"
            });

            bst.Insert(new ServiceRequest
            {
                ID = 8,
                Title = "Road Sign Damage",
                Status = "Completed",
                SubmissionDate = DateTime.Now.AddDays(-20),
                Description = "Stop sign knocked down by an accident.",
                Category = "Roads",
                Location = "Pine Street and Elm Road"
            });

            bst.Insert(new ServiceRequest
            {
                ID = 9,
                Title = "Illegal Dumping",
                Status = "Pending",
                SubmissionDate = DateTime.Now.AddDays(-1),
                Description = "Illegal dumping of construction materials observed.",
                Category = "Sanitation",
                Location = "Riverfront Area, Lane 12"
            });

            bst.Insert(new ServiceRequest
            {
                ID = 10,
                Title = "Public Park Maintenance",
                Status = "Pending",
                SubmissionDate = DateTime.Now.AddDays(-4),
                Description = "Playground equipment requires urgent repairs.",
                Category = "Utilities",
                Location = "Central Park, Zone A"
            });


            return bst.TraverseInOrder();
        }
    }

    public class ServiceRequest
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
    }

    public class Node
    {
        public ServiceRequest Request { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(ServiceRequest request)
        {
            Request = request;
            Left = null;
            Right = null;
        }
    }

    public class ServiceRequestBST
    {
        private Node Root;

        public void Insert(ServiceRequest request)
        {
            Root = Insert(Root, request);
        }

        private Node Insert(Node node, ServiceRequest request)
        {
            if (node == null) return new Node(request);

            if (request.ID < node.Request.ID)
                node.Left = Insert(node.Left, request);
            else
                node.Right = Insert(node.Right, request);

            return node;
        }

        public List<ServiceRequest> TraverseInOrder()
        {
            var result = new List<ServiceRequest>();
            TraverseInOrder(Root, result);
            return result;
        }

        private void TraverseInOrder(Node node, List<ServiceRequest> result)
        {
            if (node == null) return;

            TraverseInOrder(node.Left, result);
            result.Add(node.Request);
            TraverseInOrder(node.Right, result);
        }
    }
}