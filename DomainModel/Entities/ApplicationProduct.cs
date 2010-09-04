using System;
using System.Collections.Generic;
using System.Drawing;



namespace DomainModel.Entities
{
    public class ApplicationProduct : ProductBase
    {
        public decimal?                         Price { get; set; }
        public string                           PriceDetails { get; set; }
        public float?                           MinimumVolumeSize { get; set; } // MB
        public bool?                            MultiUser { get; set; }
        public bool?                            MultiLanguage { get; set; }
        public bool?                            LanguageExtendable { get; set; }

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
        public List<ProductCategory>            CategoryTags { get; set; }
        public List<ProductLanguage>            SupportedLanguages { get; set; }
        public List<ProductSourceOption>        SourceOptions { get; set; }
        public List<ProductEnvironmentOption>   EnvironmentOptions { get; set; }
        public List<ProductDataBackupOption>    BackupOptions { get; set; }
    }
}
