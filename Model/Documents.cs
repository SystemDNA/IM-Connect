using System.ComponentModel.DataAnnotations.Schema;

namespace MAUIAPI.Model
{
    [Table("Documents_T")]
    public class Documents
    {
        public int ID {  get; set; }
        public string? FileName {  get; set; }
        public int? FKiDocType { get; set; }
        public string? SubDirectoryPath { get; set; }
        public string? sAliasName { get; set; }
    }
}
