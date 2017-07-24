using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailEngine
{
    public class InputRecord
    {
        public InputRecord(string emailTo, string name, string thumbnailUri, string videoUri)
        {
            EmailTo = emailTo;
            Name = name;
            ThumbnailUri = new Uri(thumbnailUri);
            VideoUri = videoUri;
        }

        public string EmailTo { get; private set; }
        public string Name { get; private set; }
        public Uri ThumbnailUri { get; private set; }
        public string VideoUri { get; private set; }
    }
}
