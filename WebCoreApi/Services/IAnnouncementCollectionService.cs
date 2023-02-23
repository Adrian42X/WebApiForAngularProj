using WebCoreApi.Models;

namespace WebCoreApi.Services
{
    public interface IAnnouncementCollectionService:ICollectionService<Announcement>
    {
        Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId);
    }
}
