using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClevInvest.Models;
using ClevInvest.Services.Database;
using ClevInvest.Services.Database.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClevInvest.Pages.Investments
{
    [Authorize]
    public class ArticlePage : PageModel
    {
        private ApplicationContext _db;
        private ICommentRepository _commentRepository;

        public ArticlePage(ApplicationContext db, ICommentRepository commentRepository)
        {
            _db = db;
            _commentRepository = commentRepository;
        }

        public IEnumerable<Comment> CommentsList;

        [BindProperty] public Article Article { get; set; }
        [BindProperty] public Comment Comment { get; set; }

        public IActionResult OnGet(int id)
        {
            Article = _db.Articles.FirstOrDefault(a => a.Id == id);
            if (Article == null) return RedirectToPage("/NotFound");
            CommentsList = _commentRepository.GetAll();
            return Page();
        }

        public IActionResult OnPost(string description)
        {
            _db.Articles.FirstOrDefault(a => a.Id == Article.Id).Description = description;
            _db.SaveChanges();
            return OnGet(Article.Id);
        }

        public IActionResult OnPostComment(int id)
        {
            var user = _db.Users.FirstOrDefault(u=>u.Login == User.Identity.Name);
            var date = DateTime.Now;
             var comment = new Comment
             {
                 User = user, 
                 Date = date,
                 ArticleId = Article.Id,
                 Message = Comment.Message
             };
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return OnGet(id);
        }
    }
}