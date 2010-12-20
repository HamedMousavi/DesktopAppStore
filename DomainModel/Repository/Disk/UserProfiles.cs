using System;
using System.Collections.Generic;



namespace DomainModel.Repository.Disk
{
    public class UserProfiles
    {
        internal static void LoadLogos(long userId, List<Entities.Picture> list)
        {

            /*
                    if (Model.Profile.Logos != null && Model.Profile.Logos.Count > 0)
                    {
                    }
                    else
                    {
                        uri = "/Content/Users/Common/Images/Logo.png";
                    }
 
             */
            Entities.Picture picture = new Entities.Picture();
            picture.Url = "/Content/Images/logo.gif";
            list.Add(picture);
        }
    }
}
