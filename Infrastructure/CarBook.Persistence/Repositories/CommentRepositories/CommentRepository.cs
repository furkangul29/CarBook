using CarBook.Application.Features.ReposityoryPattern.CommentRepositories;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Add(Comment entity)
        {
          _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            var values = _context.Comments.Select(x=> new Comment
            {
                CommentID=x.CommentID,
                BlogID=x.BlogID,
                CreatedDate=x.CreatedDate,
                Description = x.Description,
                Name = x.Name,
                Email = x.Email
            }).ToList();
            return values;
        }

        public Comment GetById(int id)
        {
            var values=_context.Comments.Find(id);
            return values;
        }

        public List<Comment> GetCommentsByBlogId(int id)
        {
            var values= _context.Set<Comment>().Where(x=>x.BlogID==id).ToList();
            return values;
        }

        public void Remove(int id)
        {
            int commentId = id;
            var comment = _context.Comments.Find(commentId);
            _context.Comments.Remove(comment);
            _context.SaveChanges();

        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }
    }
}
