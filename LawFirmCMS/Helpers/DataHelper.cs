using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LawFirmCMS.Helpers
{
    public static class DataHelper
    {
        public async static Task<byte[]> GetImageFromForm(IFormCollection form, ModelStateDictionary modelState)
        {
            var file = form.Files["fileInput"];
            if (file != null && file.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(file.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    modelState.AddModelError("File", "Only image files (.jpg, .jpeg, .png, .gif) are allowed.");
                }

                if (file.Length > 5 * 1024 * 1024) // 5 MB limit
                {
                    modelState.AddModelError("File", "File size must be less than 5 MB.");
                }

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
            else
                return null;
        }

        public static string TrimText(string original, int maxCharacters)
        {
            if (string.IsNullOrEmpty(original) || original.Length <= maxCharacters)
            {
                return original;
            }
            else
            {
                return original.Substring(0, maxCharacters) + "...";
            }
        }
    }
}
