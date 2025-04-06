using AliceProject.Components.Layout;
using MudBlazor;

namespace AliceProject.Services
{
    public class BreadcrumbService : IBreadcrumbService
    {
        private List<BreadcrumbItem> _items = new();
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
            _items = [new BreadcrumbItem(text: "Home", href: "/", icon: Icons.Material.Filled.Home)];
        }

        public async Task SetItems(List<BreadcrumbItem> items)
        {
            await Reset();
            foreach (var item in items)
            {
                _items.Add(item);
            }
        }

        public async Task SetLayout(MainLayout layout)
        {
            MainLayoutInstance = layout;
        }
    }
}
