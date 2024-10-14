namespace Whm.Data.Entities.Interfaces
{
    public interface IDateTracking
    {
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
