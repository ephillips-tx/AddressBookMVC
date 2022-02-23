using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace AddressBookMVC.Models
{
    public class Contact
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; } = string.Empty;


        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        [DataType(DataType.PostalCode)]
        public int Zip { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;

        public DateTime? Created { get; set; }

        [NotMapped]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }

        public int Id { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
