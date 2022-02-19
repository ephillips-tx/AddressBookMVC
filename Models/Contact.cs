using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace AddressBookMVC.Models
{
    public class Contact
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }


        public string City { get; set; } = null!;

        public string State { get; set; } = null!;
      
        [DataType(DataType.PostalCode)]
        public int Zip { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = null!;

        public DateTime? Created { get; set; }

        [NotMapped]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; } = null!;
        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }

        public int Id { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
