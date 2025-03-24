using Microsoft.AspNetCore.Mvc;
using DigitalNamecard.Models;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace DigitalNamecard.Controllers
{
    public class NamecardController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        // In a real application, this would be replaced with a database context
        private static List<NamecardModel> _namecards = new List<NamecardModel>
        {
            new NamecardModel
            {
                Id = 1,
                FullName = "Pornchai Jansisyanont",
                JobTitle = "Dean",
                Company = "Faculty of Dentistry, Chulalongkorn University",
                Email = "pornchai.j@chula.ac.th",
                Phone = "66 2218 8659-60",
                Fax = "66 2255 3058",
                Mobile = "668 9920 9260",
                Website = "https://dent.chula.ac.th",
                Address = "34 Henri Dunant Road, Pathumwan, Bangkok 10330, THAILAND",
                Bio = "Professor and Dean of the Faculty of Dentistry, Chulalongkorn University, with extensive experience in dental education and research.",
                ProfileImageUrl = "~/images/profiles/pornchai.jpg", // ตัวอย่างเส้นทาง
                LogoUrl = "~/images/profiles/DENT-LOGO-2020-CREATE.jpeg", // ตัวอย่างเส้นทาง
                SocialLinks = new List<SocialLink>
                {

                }
            },
            //new NamecardModel
            //{
            //    Id = 2,
            //    FullName = "John Doe",
            //    JobTitle = "Software Developer",
            //    Company = "Tech Solutions Inc.",
            //    Email = "john.doe@example.com",
            //    Phone = "+1 (555) 123-4567",
            //    Fax = "+1 (555) 123-4568",
            //    Mobile = "+1 (555) 987-6543",
            //    Website = "https://johndoe.com",
            //    Address = "123 Tech Street, San Francisco, CA",
            //    Bio = "Experienced software developer with a passion for creating elegant solutions to complex problems.",
            //    ProfileImageUrl = "/images/profiles/john.jpg", // ตัวอย่างเส้นทาง
            //    LogoUrl = "/images/profiles/tech-logo.png", // ตัวอย่างเส้นทาง
            //    SocialLinks = new List<SocialLink>
            //    {
            //        new SocialLink { Id = 3, Platform = "LinkedIn", Url = "https://linkedin.com/in/johndoe", NamecardId = 2 },
            //        new SocialLink { Id = 4, Platform = "Twitter", Url = "https://twitter.com/johndoe", NamecardId = 2 },
            //        new SocialLink { Id = 5, Platform = "GitHub", Url = "https://github.com/johndoe", NamecardId = 2 }
            //    }
            //},
            new NamecardModel
            {
                Id = 2,
                FullName = "Supreda Srithanyarat",
                JobTitle = "Assistant Dean for International Affairs",
                Company = "Faculty of Dentistry, Chulalongkorn University",
                Email = "supreda.s@chula.ac.th",
                Phone = "66 2218 8847",
                Mobile = "668 1557 9042",
                Address = "34 Henri Dunant Road, Pathumwan, Bangkok 10330, THAILAND",
                Bio = "Assistant Professor and Assistant Dean for International Affairs at the Faculty of Dentistry, Chulalongkorn University, specializing in Periodontology.",
                ProfileImageUrl = "~/images/profiles/Supreda-Srithanyarat.jpg", // เส้นทางตัวอย่าง
                LogoUrl = "~/images/profiles/DENT-LOGO-2020-CREATE.jpeg", // เส้นทางตัวอย่าง
                SocialLinks = new List<SocialLink>
                {
                    // เพิ่มลิงก์โซเชียลอื่น ๆ ตามต้องการ
                }
            },
    // เพิ่มข้อมูลของ Prof. Thantrira (First) Porntaveetus
        new NamecardModel
        {
            Id = 3,
            FullName = "Thantrira Porntaveetus",
            JobTitle = "Associate Dean for Research and Innovation"+       
            "Director, Center of Excellence in Genomics and Precision Dentistry"+
            "Vice President, Thai Society of Human Genetics"+
            "Research Director, Chulalongkorn University Implant and Esthetic Dentistry Program (CUIE)"+
            "Secretary, Geriatric Dentistry and Special Patients Care Program",
            Company = "Faculty of Dentistry, Chulalongkorn University",
            Email = "thantrira.p@chula.ac.th",
            Phone = "66 2218 8695",
            Mobile = "668 1999 9939",
            Address = "34 Henri Dunant Road, Pathumwan, Bangkok 10330, THAILAND",
            Bio = "Professor and Associate Dean for Research and Innovation, with expertise in genomics and precision dentistry.",
            ProfileImageUrl = "~/images/profiles/Thantrira-Porntaveetus.jpg", // เส้นทางตัวอย่าง
            LogoUrl = "~/images/profiles/DENT-LOGO-2020-CREATE.jpeg", // เส้นทางตัวอย่าง
            SocialLinks = new List<SocialLink>
            {
                // เพิ่มลิงก์โซเชียลอื่น ๆ ตามต้องการ
            }
        },
        new NamecardModel
        {
            Id = 4,
            FullName = "Thanaphum (Noom) Osathanon",
            JobTitle = "Associate Dean for Academic Affairs and Graduate Studies",
            Company = "Faculty of Dentistry, Chulalongkorn University",
            Email = "thanaphum.o@chula.ac.th",
            Phone = "66834940005",
            Address = "Faculty of Dentistry, Chulalongkorn University, 34 Henri-Dunant Road, Wangmai, Pathumwan, Bangkok, 10330 THAILAND",
            Bio = "Professor and Chairman, Oral and Craniofacial Science Program, Chairman, Center of Excellence in Dental Stem Cell Biology, Center for Artificial Intelligence and Innovation (CAII), Dental Education Unit",
            ProfileImageUrl = "~/images/profiles/Thanaphum-Osathanon.jpg", // เส้นทางตัวอย่าง (ปรับตามจริง)
            LogoUrl = "~/images/profiles/DENT-LOGO-2020-CREATE.jpeg", // ใช้โลโก้เดียวกับคนอื่น
            SocialLinks = new List<SocialLink>
            {
                new SocialLink { Id = 8, Platform = "WhatsApp", Url = "https://wa.me/qr/E2J63CA27D4XJ1", NamecardId = 4 },
                new SocialLink { Id = 9, Platform = "LINE", Url = "https://line.me/ti/p/TAARI4ssQs", NamecardId = 4 },
                new SocialLink { Id = 10, Platform = "WeChat", Url = "https://u.wechat.com/kMGEYEIXeqR3M7ZLzBQBUs0?s=4", NamecardId = 4 },
                new SocialLink { Id = 11, Platform = "KakaoTalk", Url = "http://qr.kakao.com/talk/WxlnKcd.HthSvByymbf.Sy4RFRQ-", NamecardId = 4 },
                new SocialLink { Id = 12, Platform = "LinkedIn", Url = "https://www.linkedin.com/in/thanaphum-noom-osathanon-4b9514202", NamecardId = 4 },
                new SocialLink { Id = 13, Platform = "Facebook", Url = "https://www.facebook.com/share/1YoEXxmcSo/", NamecardId = 4 },
                new SocialLink { Id = 14, Platform = "Instagram", Url = "https://www.instagram.com/osathanon.t", NamecardId = 4 },
                new SocialLink { Id = 15, Platform = "PubMed", Url = "https://pubmed.ncbi.nlm.nih.gov/?term=Osathanon&sort=date", NamecardId = 4 }
            }
        }


        };

        public NamecardController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Namecard
        public IActionResult Index()
        {
            return View(_namecards);
        }

        // GET: Namecard/Create
        public IActionResult Create()
        {
            return View(new NamecardModel());
        }

        // POST: Namecard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NamecardModel namecard, IFormFile profileImage, IFormFile logoImage)
        {
            if (ModelState.IsValid)
            {
                // Handle profile image upload
                if (profileImage != null)
                {
                    string profilePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "profiles", profileImage.FileName);
                    using (var stream = new FileStream(profilePath, FileMode.Create))
                    {
                        profileImage.CopyTo(stream);
                    }
                    namecard.ProfileImageUrl = $"/images/profiles/{profileImage.FileName}";
                }

                // Handle logo image upload
                if (logoImage != null)
                {
                    string logoPath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "profiles", logoImage.FileName);
                    using (var stream = new FileStream(logoPath, FileMode.Create))
                    {
                        logoImage.CopyTo(stream);
                    }
                    namecard.LogoUrl = $"/images/profiles/{logoImage.FileName}";
                }

                // In a real application, save to database
                namecard.Id = _namecards.Count > 0 ? _namecards.Max(n => n.Id) + 1 : 1;
                namecard.CreatedAt = DateTime.Now;
                namecard.UpdatedAt = DateTime.Now;
                _namecards.Add(namecard);
                return RedirectToAction(nameof(View), new { id = namecard.Id });
            }
            return View(namecard);
        }

        // GET: Namecard/View/5
        public IActionResult View(int id)
        {
            var namecard = _namecards.Find(n => n.Id == id);
            if (namecard == null)
            {
                return NotFound();
            }
            return View(namecard);
        }

        // GET: Namecard/Edit/5
        public IActionResult Edit(int id)
        {
            var namecard = _namecards.Find(n => n.Id == id);
            if (namecard == null)
            {
                return NotFound();
            }
            return View(namecard);
        }

        // POST: Namecard/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, NamecardModel namecard, IFormFile profileImage, IFormFile logoImage)
        {
            if (id != namecard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Handle profile image upload
                if (profileImage != null)
                {
                    string profilePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "profiles", profileImage.FileName);
                    using (var stream = new FileStream(profilePath, FileMode.Create))
                    {
                        profileImage.CopyTo(stream);
                    }
                    namecard.ProfileImageUrl = $"/images/profiles/{profileImage.FileName}";
                }

                // Handle logo image upload
                if (logoImage != null)
                {
                    string logoPath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "profiles", logoImage.FileName);
                    using (var stream = new FileStream(logoPath, FileMode.Create))
                    {
                        logoImage.CopyTo(stream);
                    }
                    namecard.LogoUrl = $"/images/profiles/{logoImage.FileName}";
                }

                // In a real application, update in database
                var index = _namecards.FindIndex(n => n.Id == id);
                if (index >= 0)
                {
                    namecard.UpdatedAt = DateTime.Now;
                    _namecards[index] = namecard;
                }
                return RedirectToAction(nameof(View), new { id = namecard.Id });
            }
            return View(namecard);
        }

        // GET: Namecard/Delete/5
        public IActionResult Delete(int id)
        {
            var namecard = _namecards.Find(n => n.Id == id);
            if (namecard == null)
            {
                return NotFound();
            }
            return View(namecard);
        }

        // POST: Namecard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var namecard = _namecards.Find(n => n.Id == id);
            if (namecard != null)
            {
                _namecards.Remove(namecard);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Namecard/GenerateQR/5
        public IActionResult GenerateQR(int id)
        {
            var namecard = _namecards.Find(n => n.Id == id);
            if (namecard == null)
            {
                return NotFound();
            }
            ViewBag.NamecardId = id;
            ViewBag.Namecard = namecard;
            return View();
        }
    }
}