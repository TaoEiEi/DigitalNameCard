using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalNamecard.Models
{
    public class NamecardModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        [Phone(ErrorMessage = "Invalid fax number")]
        public string Fax { get; set; } // ‡æ‘Ë¡ø‘≈¥Ï Fax

        [Display(Name = "Mobile")]
        [Phone(ErrorMessage = "Invalid mobile number")]
        public string Mobile { get; set; } // ‡æ‘Ë¡ø‘≈¥Ï Mobile

        [Display(Name = "Website")]
        [Url(ErrorMessage = "Invalid URL")]
        public string Website { get; set; }

        [Display(Name = "Bio")]
        public string Bio { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Profile Image URL")]
        [Url(ErrorMessage = "Invalid URL for profile image")]
        public string ProfileImageUrl { get; set; } // ‡æ‘Ë¡ø‘≈¥Ï ProfileImageUrl

        [Display(Name = "Logo URL")]
        [Url(ErrorMessage = "Invalid URL for logo")]
        public string LogoUrl { get; set; } // ‡æ‘Ë¡ø‘≈¥Ï LogoUrl

        public List<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    public class SocialLink
    {
        public int Id { get; set; }
        public string Platform { get; set; }
        public string Url { get; set; }
        public int NamecardId { get; set; }
    }
}