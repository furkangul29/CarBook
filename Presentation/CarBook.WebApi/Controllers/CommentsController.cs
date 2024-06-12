using CarBook.Application.Features.ReposityoryPattern.CommentRepositories;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var comments = _commentRepository.GetAll();
            return Ok(comments);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _commentRepository.Add(comment);
            return Ok("Yorm Başarı İle Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Yorum Baraşı ile Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            _commentRepository.Remove(id);
            return Ok("Yorum Başarı İle Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var comment = _commentRepository.GetById(id);
            return Ok(comment);
        }
    

        
    }
}
