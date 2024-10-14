namespace Whm.Infrastructure.Helpers
{
    public class ViewPaging<T> where T : class
    {
        public IList<T> Items { get; set; }
        public Pagination Pagination { get; set; }

        public ViewPaging(IList<T> items, Pagination pagination)
        {
            Items = items;
            Pagination = pagination;
        }
    }
}
