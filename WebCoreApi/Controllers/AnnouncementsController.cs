using Microsoft.AspNetCore.Mvc;
using WebCoreApi.Models;
using WebCoreApi.Services;

namespace WebCoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AnnouncementsController : ControllerBase
    {
        IAnnouncementCollectionService _announcementCollectionService;
        public AnnouncementsController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new ArgumentNullException(nameof(AnnouncementCollectionService));
        }


        [HttpGet]
        public async Task<IActionResult> GetAnnouncements()
        {
            List<Announcement> announcements = await _announcementCollectionService.GetAll();
            return Ok(announcements);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnnouncements([FromBody] Announcement announcement)
        {
            if (await _announcementCollectionService.Create(announcement))
                return Ok(announcement);
            else
                return BadRequest("This announcement already exist or the new announcement does't correspond");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnnoncement(Guid id, [FromBody] Announcement announcement)
        {
            if (await _announcementCollectionService.Update(id, announcement))
                return Ok(announcement);

            return StatusCode(StatusCodes.Status404NotFound, "Error in processing the AnnouncementUpdate");
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAnnouncement(Guid Id)
        {
            if (await _announcementCollectionService.Delete(Id))
                return StatusCode(StatusCodes.Status202Accepted);

            return StatusCode(StatusCodes.Status404NotFound, "Error in processing the AnnouncementDelete");
        }

    }
}
