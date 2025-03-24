using BlazorApp2.Components.Layout;
using MudBlazor;

namespace BlazorApp2.Services
{
    public interface IBreadcrumbService
    {
        Task SetLayout(MainLayout layout);
        Task RefreshLayout();
        Task<List<BreadcrumbItem>> GetItems();
        Task AddItem(BreadcrumbItem item);
        Task RemoveItem(BreadcrumbItem item);
        Task Reset();

    }
}
