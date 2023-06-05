using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.RichTextEditor.Internal;

namespace LinkSammlungWebApp.Data
{
    public class Linksammlung
    {
        public String id
        {
            get; set;
        }
        public string linkName { get; set; }

        public string linkURL { get; set; }

        public string erstellung { get; set; }

        public Linksammlung() { }

        public Linksammlung(string linkName, string linkURL, string id, string erstellung)
        {
            this.linkName = linkName;
            this.linkURL = linkURL;
            this.id = id;
            this.erstellung = erstellung;
        }
    }
}
