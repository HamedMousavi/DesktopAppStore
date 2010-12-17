using System;
using DomainModel.Entities;
using System.Collections.Generic;



namespace DomainModel.Membership
{
    public class UserProfile
    {
        public Forum Forum { get; set; }
        public List<ProductContact> Contacts { get; set; }
        public List<DomainModel.Entities.Picture> Logos { get; set; }
        public DomainModel.Entities.ProductOwner Ownership { get; set; }


        // User selected culture for UI
        private string culture;
        public string Culture 
        {
            get
            {
                return this.culture;
            }

            set
            {
                if (this.culture != value)
                {
                    this.culture = value;
                    this.hasUnsavedChanges = true;
                }
            }
        }

        // User display name in forums and profile
        // Sftware owners can have a culture-related name
        private string dislayName;
        public string DislayName
        {
            get
            {
                return this.dislayName;
            }

            set
            {
                if (this.dislayName != value)
                {
                    this.dislayName = value;
                    this.hasUnsavedChanges = true;
                }
            }
        }


        private bool hasUnsavedChanges;
        public bool HasUnsavedChanges
        {
            get
            {
                return this.hasUnsavedChanges;
            }

            set
            {
                if (this.hasUnsavedChanges != value)
                {
                    this.hasUnsavedChanges = value;
                }
            }
        }


        public UserProfile()
        {
            this.hasUnsavedChanges = false;
            this.Ownership = new ProductOwner();
        }


        public void Update(UserProfile profile)
        {
            this.Culture = profile.Culture;
            this.DislayName = profile.DislayName;
        }
    }
}
