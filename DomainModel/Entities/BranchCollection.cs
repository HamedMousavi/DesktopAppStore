using System;
using System.Collections.Generic;




namespace DomainModel.Entities
{
    public class BranchCollection : List<OwnerBranch>
    {
        public OwnerBranch this[Int64? id]
        {
            get
            {
                if (id == null) return null;

                foreach (OwnerBranch item in this)
                {
                    if (item.Id == id)
                    {
                        return item;
                    }
                }

                return null;
            }
        }
    }
}
