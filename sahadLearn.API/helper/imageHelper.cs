namespace sahadLearn.API.helper
{
    public static class imageHelper
    {
        private static readonly string[] allowed = { ".jpg", ".jpeg", ".png" };
        private const long maxSize = 5 * 1024 * 1024; // 5 MB

        // returns an error message, or null if the file is valid
        public static string? ValidateImage(IFormFile? file)
        {
            if (file == null) return null;

            if (!allowed.Contains(Path.GetExtension(file.FileName).ToLower()))
                return "Only .jpg, .jpeg and .png files are allowed.";

            if (file.Length > maxSize)
                return "File size must be 5 MB or less.";

            return null;
        }
    }
}
