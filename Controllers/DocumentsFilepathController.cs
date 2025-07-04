using MAUIAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace MAUIAPI.Controllers
{
    public class DocumentsFilepathController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public DocumentsFilepathController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public string FilePath(int DocID)
        {
            string ImagePath = "";
            var Documents = _context.Documents.Where(k => k.ID == DocID).FirstOrDefault();
            string physicalPath = _configuration["AppSettings:PhysicalPath"];
            if (Documents != null && Documents.ID > 0)
            {
                var ImgType = "";
                var FileTypeID = Documents.FKiDocType;
                var subdire = Documents.SubDirectoryPath;
                var filename = Documents.FileName;
                string newFilename = AddOrginalToFilename(filename);
                if (FileTypeID == 1)
                {
                    ImgType = "png";
                  
                }
                else if (FileTypeID == 2)
                {
                    ImgType = "jpg";
                }

                ImagePath = physicalPath + ImgType + "//" + subdire + "//" + newFilename;
            }
            return ImagePath;
        }

        static string AddOrginalToFilename(string filename)
        {
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
            string extension = Path.GetExtension(filename);

            // If no extension, handle accordingly
            if (string.IsNullOrEmpty(extension))
                return $"{nameWithoutExtension}_Orginal";
            else
                return $"{nameWithoutExtension}_Orginal{extension}";
        }
    }
}
