using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Enums
{
    public enum PageElementType
    {
        Heading = 0,
        [Display(Name = "Rich text")]
        RichText = 1,
        Image = 2,
        Employee = 3,
    }
}
