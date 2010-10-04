using System;
using System.Collections.Generic;
using System.Drawing;



namespace DomainModel.Entities
{
    public class ApplicationProduct : ProductBase
    {
        public ApplicationProduct()
            : base()
        {
            this.MinimumVolumeSize = null;
            this.MultiUser = false;
            this.LanguageExtendable = false;

            this.HardwareRequirements = new List<string>();
            
            this.Brands = new List<ProductBrand>();
            this.ExtensionOptions = new List<ProductExtensionOptions>();
            this.PaymentOptions = new List<ProductPaymentOption>();
            this.PublishOptions = new List<ProductPublishOption>();
            this.DemoOptions = new List<ProductDemoOption>();
            this.TrainingOptions = new List<ProductTrainingOption>();
            this.SupportOptions = new List<ProductSupportOption>();
            this.SupportTypes = new List<ProductSupportType>();
            this.GuarantyOptions = new List<ProductGuarantyOption>();
            this.CustomizationOptions = new List<ProductCustomizationOption>();
            this.InstallationOptions = new List<ProductInstallationOption>();
            this.UpdateOptions = new List<ProductUpdateOption>();
            this.ProductContacts = new List<ProductContact>();
            this.Tags = new List<ProductTag>();
            this.SupportedLanguages = new List<ProductLanguage>();
            this.SourceOptions = new List<ProductSourceOption>();
            this.EnvironmentOptions = new List<ProductEnvironmentOption>();
            this.BackupOptions = new List<ProductDataBackupOption>();
        }

        public float?                           MinimumVolumeSize { get; set; } // MB
        public bool                             MultiUser { get; set; }
        public bool                             LanguageExtendable { get; set; }

        public List<string>                     HardwareRequirements { get; set; }
        public List<ProductBrand>               Brands { get; set; }
        public List<ProductExtensionOptions>    ExtensionOptions { get; set; }
        public List<ProductPaymentOption>       PaymentOptions { get; set; }
        public List<ProductPublishOption>       PublishOptions { get; set; }
        public List<ProductDemoOption>          DemoOptions { get; set; }
        public List<ProductTrainingOption>      TrainingOptions { get; set; }
        public List<ProductSupportOption>       SupportOptions { get; set; }
        public List<ProductSupportType>         SupportTypes { get; set; }
        public List<ProductGuarantyOption>      GuarantyOptions { get; set; }
        public List<ProductCustomizationOption> CustomizationOptions { get; set; }
        public List<ProductInstallationOption>  InstallationOptions { get; set; }
        public List<ProductUpdateOption>        UpdateOptions { get; set; }
        public List<ProductContact>             ProductContacts { get; set; }
        public List<ProductTag>                 Tags { get; set; }
        public List<ProductLanguage>            SupportedLanguages { get; set; }
        public List<ProductSourceOption>        SourceOptions { get; set; }
        public List<ProductEnvironmentOption>   EnvironmentOptions { get; set; }
        public List<ProductDataBackupOption>    BackupOptions { get; set; }
    }
}
