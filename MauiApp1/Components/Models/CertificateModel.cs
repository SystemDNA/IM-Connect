// Models/CertificateModel.cs
namespace MauiApp1.Models
{
    public class CertificateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public DateTime DateIssued { get; set; }
        public string ImageUrl { get; set; }

        public CertificateModel(string title, string description, string number, DateTime dateIssued, string imageUrl = "/images/sample-certificate.png")
        {
            Title = title;
            Description = description;
            Number = number;
            DateIssued = dateIssued;
            ImageUrl = imageUrl;
        }
    }
}
