namespace FamilyOrgaBack.Models
{
    public class FamilyOrgaDBSettings : IFamilyOrgaDBSettings
    {
        public string ShoppingListCollectionName {get; set;}
        public string ConnectionString {get; set;}
        public string DatabaseName {get; set;}
    }

    public interface IFamilyOrgaDBSettings
    {
        
        public string ShoppingListCollectionName {get; set;}
        public string ConnectionString {get; set;}
        public string DatabaseName {get; set;}
    }
}