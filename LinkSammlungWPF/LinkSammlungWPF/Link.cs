using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace LinkSammlungWPF
{
    class Link
    {

        public String id
        {
            get; set;
        }
        public string linkName { get; set; }

        public string linkURL { get; set; }

        public string erstellung { get; set; }

        public Link() { }

        public Link(string id, string linkName, string linkURL)
        {
            this.id = id;
            this.linkName = linkName;
            this.linkURL = linkURL;
        }
    }
}
