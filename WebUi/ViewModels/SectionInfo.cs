
using System.Collections.Generic;
namespace WebUi.ViewModels
{
    public class SectionInfo
    {
        public string Section { get; set; }
        public string SubSection { get; set; }

        public List<WebUi.ViewModels.SectionLinkInfo> Menu { get; set; }
    }
}