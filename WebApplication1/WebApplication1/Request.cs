namespace WebApplication1
{
    public class Request
    {
        public string? key { get; set; }
        public string? body { get; set; }
        public string? id { get; set; }

        public bool coordinates { get; set; }
        public bool recaptcha { get; set; }

        public bool cna { get; set; }
        public bool russian { get; set; }
        public string? instructions { get; set; }
        public string? finstructions { get; set; }
        public string? cols { get; set; }
        public string? rows { get; set; }

        public string? regsense { get; set; }
        public string? phrase { get; set; }
        public string? numeric { get; set; }

    }
}
