using BT2_Nhom3_23WebC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BT2_Nhom3_23WebC.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new ContactViewModel
            {
                Description = "Morbi adipiscing gravida lacus, id rhoncus neque sollicitudin ac. Sed eget purus vitae enim pulvinar viverra. Cras ut elit et ligula blandit eleifend. Nam at odio sem, sed tempor justo.",
                Offices = new List<OfficeContact>
            {
                new OfficeContact
                {
                    OfficeName = "Office One",
                    Address = "800-220 Fusce nec ante at odio, In vitae lacus in purus, 66770<br />Diam a mollis tempor",
                    Phone = "010-440-5500",
                    Email = "contact@company.com"
                },
                new OfficeContact
                {
                    OfficeName = "Office Two",
                    Address = "600-110 Duis lacinia, Ullamcorper mattis, 88770<br />Maecenas a diam, mollis magna",
                    Phone = "020-660-8800",
                    Email = "info@company.com"
                }
            },
                ContactForm = new ContactFormViewModel()
            };
            return View(model);
        }
        private List<OfficeContact> GetOfficeContacts()
        {
            return new List<OfficeContact>
    {
        new OfficeContact
        {
            OfficeName = "Office One",
            Address = "800-220 Fusce nec ante at odio, In vitae lacus in purus, 66770<br />Diam a mollis tempor",
            Phone = "010-440-5500",
            Email = "contact@company.com"
        },
        new OfficeContact
        {
            OfficeName = "Office Two",
            Address = "600-110 Duis lacinia, Ullamcorper mattis, 88770<br />Maecenas a diam, mollis magna",
            Phone = "020-660-8800",
            Email = "info@company.com"
        }
    };
        }
        [HttpPost]
        public IActionResult Index(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Xử lý gửi email hoặc lưu thông tin liên hệ
                // Có thể thêm thông báo thành công
                return RedirectToAction("Success");
            }
            model.Offices = GetOfficeContacts(); // Truyền lại thông tin Offices như ở GET để render lại
        return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
