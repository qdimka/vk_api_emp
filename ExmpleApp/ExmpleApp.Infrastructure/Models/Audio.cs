using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;

namespace ExmpleApp.Infrastructure.Models
{
    public class Audio
    {
        public string Artist { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public Uri Url { get; set; }

        public long? LyricsId { get; set; }

        public long? AlbumId { get; set; }

        public string Genre { get; set; }

        public DateTime? Date { get; set; }

    }
}
