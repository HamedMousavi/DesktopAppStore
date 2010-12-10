using System;
using System.Collections;
using System.IO;



namespace DomainModel.Repository.Disk
{
    public class ByDateFileComparer:IComparer
    {

        #region IComparer Members

        public int Compare(object x, object y)
        {
            try
            {
                DateTime ctx = (x as FileInfo).CreationTime;
                DateTime cty = (y as FileInfo).CreationTime;

                return DateTime.Compare(cty, ctx);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Exception:{0}", ex));
                return 0;
            }
        }

        #endregion
    }
}
