using AliceProject.Components.Layout;
using MudBlazor;

namespace AliceProject.Services
{
    public interface IBreadcrumbService
    {
        Task SetLayout(MainLayout layout);
        Task RefreshLayout();
        Task<List<BreadcrumbItem>> GetItems();
        Task SetItems(List<BreadcrumbItem> items);
        Task AddItem(BreadcrumbItem item);
        Task RemoveItem(BreadcrumbItem item);
        Task Reset();

    }
}
