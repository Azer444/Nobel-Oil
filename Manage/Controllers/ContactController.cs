using Core;
using Core.Constants;
using Core.Models;
using Manage.MiddlewareFilters;
using Manage.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var contactPage = await _unitOfWork.PageMainPhoto.GetByPageAsync(Page.Contact);
            if (contactPage == null) return NotFound();

            var model = new IndexViewModel
            {
                SiteConfig = await _unitOfWork.SiteConfig.GetAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Message(ContactSubmitForm contactSubmitForm)
        {
            if (ModelState.IsValid)
            {
                var contactMessage = new ContactMessage
                {
                    FullName = contactSubmitForm.FullName,
                    Email = contactSubmitForm.Email,
                    Phone = contactSubmitForm.Phone,
                    Subject = contactSubmitForm.Subject,
                    Message = contactSubmitForm.Message
                };

                await _unitOfWork.ContactMessages.CreateAsync(contactMessage);
                await _unitOfWork.CommitAsync();

                return Ok();
            }

            return NotFound();
        }
    }
}
