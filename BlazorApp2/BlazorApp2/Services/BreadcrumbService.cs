using BlazorApp2.Components.Layout;
using MudBlazor;

namespace BlazorApp2.Services
{
    public class BreadcrumbService : IBreadcrumbService
    {
        private List<BreadcrumbItem> _items = [new("Home","/")];
        public MainLayout MainLayoutInstance { get; set; }
        public async Task AddItem(BreadcrumbItem item)
        {
            _items.Add(item);
        }

        public async Task<List<BreadcrumbItem>> GetItems()
        {
            return _items;
        }

        public async Task RefreshLayout()
        {
            MainLayoutInstance.RefreshLayout();
        }

        public async Task RemoveItem(BreadcrumbItem item)
        {
            _items.Remove(item);
        }

        public async Task Reset()
        {
            _items = [new("Home", "/")];
        }

        public async Task SetLayout(MainLayout layout)
        {
            MainLayoutInstance = layout;
        }
    }
}
