using System;



namespace DomainModel.Entities
{
    public class ProductImage : Picture
    {
        public string Description { get; set; }
        public ImageThumbnail Thumbnail { get; set; }
        public System.Drawing.Size ImageSize { get; set; }


        public ProductImage()
        {
            this.Thumbnail = new ImageThumbnail();
        }
    }
}
