using Microsoft.AspNetCore.Http;

namespace LearnHub.File.Interface
{ 
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);
    }
}
