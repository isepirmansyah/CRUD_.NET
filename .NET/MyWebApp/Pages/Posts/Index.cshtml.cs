using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Pages.Posts
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get; set; } = new List<Post>();
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int pageNumber = 1)
        {
            PageNumber = pageNumber;
            var totalPosts = await _context.Posts.CountAsync();
            TotalPages = (int)Math.Ceiling(totalPosts / (double)PageSize);


            Post = await _context.Posts
                .OrderByDescending(p => p.CreatedAt)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .Include(p => p.User)
                .ToListAsync();
        }
    }
}