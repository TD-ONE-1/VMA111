namespace RMS.Common.Helper
{
    public class FileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string Save(IFormFile file, string folder)
        {
            if (file == null) return null;

            string root = Path.Combine(_env.WebRootPath, folder);

            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);

            string uniqueName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            string filePath = Path.Combine(root, uniqueName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"{folder}/{uniqueName}";
        }
    }
}
