using System.ComponentModel.DataAnnotations;

namespace MAUIAPI.Constants
{
    public enum DevicePlatform
    {
            Android = 1,
            [Display(Name = "IOS")]
            iOS = 2,
            Desktop = 3
        
    }
}
