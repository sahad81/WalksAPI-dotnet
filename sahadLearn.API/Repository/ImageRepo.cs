namespace sahadLearn.API.Repository
{
    public interface IImageService
    {
        Task<string> Upload(IFormFile file);
        void Delete(string? imageUrl);
    }

    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor accessor;

        public ImageService(IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            this.env = env;
            this.accessor = accessor;
        }

        public async Task<string> Upload(IFormFile file)
        {
            var folder = Path.Combine(env.ContentRootPath, "wwwroot", "Images");
            Directory.CreateDirectory(folder);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(folder, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            var req = accessor.HttpContext!.Request;
            return $"{req.Scheme}://{req.Host}{req.PathBase}/Images/{fileName}";
        }

        public void Delete(string? imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl)) return;

            var fileName = Path.GetFileName(new Uri(imageUrl).LocalPath);
            var path = Path.Combine(env.ContentRootPath, "wwwroot", "Images", fileName);

            if (File.Exists(path)) File.Delete(path);
        }
    }
}