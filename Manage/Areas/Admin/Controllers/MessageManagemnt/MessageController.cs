using Core;
using Manage.Areas.Admin.Models.MessageManagement.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Areas.Admin.Controllers.MessageManagemnt
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class MessageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new MessageIndexViewModel
            {
                ContactMessages = (await _unitOfWork.ContactMessages.GetAllAsync()).OrderByDescending(c => c.Id).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Look(int id)
        {
            var contactMessage = await _unitOfWork.ContactMessages.GetAsync(id);
            if (contactMessage == null) return NotFound();

            var model = new MessageLookViewModel
            {
                Id = contactMessage.Id,
                FullName = contactMessage.FullName,
                Email = contactMessage.Email,
                Subject = contactMessage.Subject,
                Phone = contactMessage.Phone,
                Message = contactMessage.Message
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Look(MessageLookViewModel model)
        {
            var contactMessage = await _unitOfWork.ContactMessages.GetAsync(model.Id);
            if (contactMessage == null) return NotFound();

            if (ModelState.IsValid)
            {
                contactMessage.IsRead = model.IsRead;

                await _unitOfWork.ContactMessages.EditAsync(contactMessage);
                await _unitOfWork.CommitAsync();

                return RedirectToAction("index");
            }

            return View(model);
        }
    }
}
