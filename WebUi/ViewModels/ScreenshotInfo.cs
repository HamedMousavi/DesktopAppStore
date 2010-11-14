using System;
using System.Collections.Generic;



namespace WebUi.ViewModels
{
    public class ScreenshotInfo
    {
        public int CurrentImageIndex { get; set; }
        public string ProductName { get; set; }
        public List<DomainModel.Entities.ProductImage> Screenshots { get; set; }


        public ScreenshotInfo(int CurrentImageIndex, List<DomainModel.Entities.ProductImage> Screenshots, string ProductName)
        {
            this.ProductName = ProductName;
            this.CurrentImageIndex = CurrentImageIndex;
            this.Screenshots = Screenshots;
        }
    }
}