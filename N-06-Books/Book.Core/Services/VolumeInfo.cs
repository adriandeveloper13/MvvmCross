using System.Collections.Generic;

namespace Book.Core.Services
{
    public class VolumeInfo
    {
        public string title { get; set; }
        public List<string> authors { get; set; }

        public string authorSummary
        {
            get { return authors == null ? "-" : string.Join(", ", authors); }
        }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
        public int pageCount { get; set; }
        public int averageRating { get; set; }
        public int ratingsCount { get; set; }
        public ImageLinks imageLinks { get; set; }
        public string language { get; set; }
        public string previewLink { get; set; }
        public string infoLink { get; set; }
        public string canonicalVolumeLink { get; set; }

    }
}