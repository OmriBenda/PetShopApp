using System.ComponentModel.DataAnnotations;

namespace PetShopApp.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ImageValidAttribute : ValidationAttribute
    {
        private readonly string[] extensions;

        public ImageValidAttribute(string[] extensions)
        {
            this.extensions = extensions;
        }
        public override bool IsValid(object? value)
        {
            var path = value as string;
            if (path is not null)
            {
                int dotIndex = path.LastIndexOf('.');
                string pathExtension = path[(dotIndex + 1)..].ToLower();
                if (extensions.Contains(pathExtension))
                    return true;
            }
            return false;
        }
    }
}
