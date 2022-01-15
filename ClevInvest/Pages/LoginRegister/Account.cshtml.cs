using System;
using System.IO;
using System.Linq;
using ClevInvest.Models;
using ClevInvest.Services.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClevInvest.Pages.LoginRegister
{
    public class Account : PageModel
    {
        private ApplicationContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Account(ApplicationContext applicationContext, IWebHostEnvironment webHostEnvironment)
        {
            _db = applicationContext;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty] public User AuthorizedUser { get; set; }

        [BindProperty] public IFormFile Photo { get; set; }

        public void OnGet()
        {
            var login = User.Identity.Name;
            AuthorizedUser = _db.Users.FirstOrDefault(u => u.Login == login);
        }

        public void OnPost()
        {
            var isPhotoUpdated = false;
            if (Photo != null)
            {
                if (AuthorizedUser.UserPhoto != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "avatars",
                        AuthorizedUser.UserPhoto);
                    System.IO.File.Delete(filePath);
                }

                if (Photo.FileName != AuthorizedUser.UserPhoto)
                {
                    AuthorizedUser.UserPhoto = ProcessUploadedFile();
                    isPhotoUpdated = true;
                }
            }

            if (isPhotoUpdated)
                _db.Users.FirstOrDefault(u => u.Id == AuthorizedUser.Id).UserPhoto = AuthorizedUser.UserPhoto;
            
            _db.Users.FirstOrDefault(u => u.Id == AuthorizedUser.Id).BirthDate = AuthorizedUser.BirthDate;
            _db.Users.FirstOrDefault(u => u.Id == AuthorizedUser.Id).UserName = AuthorizedUser.UserName;
            _db.SaveChanges();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "avatars");
                uniqueFileName = Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }

            return uniqueFileName;
        }
    }
}