//using Core;
//using Core.Models;
//using Manage.Areas.Admin.Models.NotificationManagement.Notification;
//using Manage.Areas.Admin.Models.NotificationManagement.Notification.ContactMessage;
//using Manage.Tools.EmailHandler;
//using Manage.Tools.EmailHandler.Abstract;
//using Manage.ViewModels.EthicsAndCompilance;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Manage.Areas.Admin.Controllers.NotificationManagement
//{
//    [Area("Admin")]
//    [Authorize(Roles = "Staff")]
//    public class NotificationController : Controller
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public NotificationController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        #region ContactMessage

//        [HttpGet]
//        public async Task<IActionResult> ContactMessage()
//        {
//            ViewBag.NotificationManagement = true;
//            ViewBag.ContactMessage = true;

//            var model = new ContactMessageListViewModel
//            {
//                ContactMessages = await _unitOfWork.ContactMessages.GetAllAsync()
//            };

//            return View(model);
//        }

//        [HttpGet]
//        public async Task<IActionResult> ContactMessageEdit(int id)
//        {
//            ViewBag.NotificationManagement = true;
//            ViewBag.ContactMessage = true;

//            var contactMessage = await _unitOfWork.ContactMessages.GetAsync(id);
//            if (contactMessage == null) return NotFound();

//            var model = new ContactMessageEditViewModel
//            {
//                FullName = contactMessage.FullName,
//                Email = contactMessage.Email,
//                Phone = contactMessage.Phone,
//                Subject = contactMessage.Subject,
//                Message = contactMessage.Message,
//                ToEmail = contactMessage.ToEmail,
//                IsRead = contactMessage.IsRead
//            };

//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> ContactMessageEdit(ContactMessageEditViewModel model)
//        {
//            ViewBag.NotificationManagement = true;
//            ViewBag.ContactMessage = true;

//            var contactMessage = await _unitOfWork.ContactMessages.GetAsync(model.Id);
//            if (contactMessage == null) return NotFound();

//            if (ModelState.IsValid)
//            {
//                contactMessage.IsRead = model.IsRead;

//                await _unitOfWork.ContactMessages.EditAsync(contactMessage);
//                await _unitOfWork.CommitAsync();

//                TempData["message"] = $"Contact message <{contactMessage.Phone}> successfully created.";
//                TempData["message_type"] = "success";

//                return RedirectToAction("contactmessage");
//            }

//            return View(model);
//        }

//        [HttpGet]
//        public async Task<IActionResult> ContactMessageDetails(int id)
//        {
//            ViewBag.NotificationManagement = true;
//            ViewBag.ContactMessage = true;

//            var contactMessage = await _unitOfWork.ContactMessages.GetAsync(id);
//            if (contactMessage == null) return NotFound();

//            var model = new ContactMessageDetailsViewModel
//            {
//                FullName = contactMessage.FullName,
//                Email = contactMessage.Email,
//                Phone = contactMessage.Phone,    
//                Subject = contactMessage.Subject,
//                Message = contactMessage.Message,
//                ToEmail = contactMessage.ToEmail,
//                IsRead = contactMessage.IsRead,
//                CreatedAt = contactMessage.CreatedAt,
//                UpdatedAt = contactMessage.UpdatedAt
//            };

//            return View(model);
//        }

//        #endregion

//        #region EthicsAndCompilanceApply

//        [HttpGet]
//        public async Task<IActionResult> EthicsAndCompilanceApply()
//        {
//            ViewBag.NotificationManagement = true;
//            ViewBag.EthicsAndCompilanceApply = true;

//            var model = new EthicsAndCompilanceApplyListViewModel
//            {
//                EthicsAndCompilanceApplies = await _unitOfWork.EthicsAndCompilanceApplies.GetAllAsync()
//            };

//            return View(model);
//        }

//        [HttpGet]
//        public async Task<IActionResult> EthicsAndCompilanceApplyEdit(int id)
//        {
//            ViewBag.NotificationManagement = true;
//            ViewBag.EthicsAndCompilanceApply = true;

//            var ethicsAndCompilanceApply = await _unitOfWork.EthicsAndCompilanceApplies.GetAsync(id);
//            if (ethicsAndCompilanceApply == null) return NotFound();

//            var model = new EthicsAndCompilanceApplyEditViewModel
//            {
//                FullName = ethicsAndCompilanceApply.FullName,
//                Email = ethicsAndCompilanceApply.Email,
//                Phone = ethicsAndCompilanceApply.Phone,
//                Message = ethicsAndCompilanceApply.Message,
//                ToEmail = ethicsAndCompilanceApply.ToEmail,
//                IsRead = ethicsAndCompilanceApply.IsRead
//            };

//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> EthicsAndCompilanceApplyEdit(EthicsAndCompilanceApplyEditViewModel model)
//        {
//            ViewBag.NotificationManagement = true;
//            ViewBag.EthicsAndCompilanceApply = true;

//            var ethicsAndCompilanceApply = await _unitOfWork.EthicsAndCompilanceApplies.GetAsync(model.Id);
//            if (ethicsAndCompilanceApply == null) return NotFound();

//            if (ModelState.IsValid)
//            {
//                ethicsAndCompilanceApply.IsRead = model.IsRead;

//                await _unitOfWork.EthicsAndCompilanceApplies.EditAsync(ethicsAndCompilanceApply);
//                await _unitOfWork.CommitAsync();

//                TempData["message"] = $"Ethics and compilance apply <{ethicsAndCompilanceApply.Phone}> successfully created.";
//                TempData["message_type"] = "success";

//                return RedirectToAction("ethicsandcompilanceapply");
//            }

//            return View(model);
//        }

//        [HttpGet]
//        public async Task<IActionResult> EthicsAndCompilanceApplyDetails(int id)
//        {
//            ViewBag.NotificationManagement = true;
//            ViewBag.EthicsAndCompilanceApply = true;

//            var ethicsAndCompilanceApply = await _unitOfWork.EthicsAndCompilanceApplies.GetAsync(id);
//            if (ethicsAndCompilanceApply == null) return NotFound();

//            var model = new EthicsAndCompilanceApplyDetailsViewModel
//            {
//                FullName = ethicsAndCompilanceApply.FullName,
//                Email = ethicsAndCompilanceApply.Email,
//                Phone = ethicsAndCompilanceApply.Phone,
//                Message = ethicsAndCompilanceApply.Message,
//                ToEmail = ethicsAndCompilanceApply.ToEmail,
//                IsRead = ethicsAndCompilanceApply.IsRead,
//                CreatedAt = ethicsAndCompilanceApply.CreatedAt,
//                UpdatedAt = ethicsAndCompilanceApply.UpdatedAt
//            };

//            return View(model);
//        }

//        #endregion

//    }
//}
