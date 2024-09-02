using AuctionSystemApp.Domain.Entities;
using AuctionSystemApp.Domain.Factories;
using AuctionSystemApp.Domain.Interfaces.RepositoriesInterfaces;
using AuctionSystemApp.Domain.Interfaces.ServicesInterfaces;

namespace AuctionSystemApp.Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository;
        public CommentService(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<bool> AddComment(Dictionary<string, string> body)
        {
            var comment = CommentFactory.CreateComment(body);
            var result = await _commentRepository.AddAsync(comment);
            if (result == null)
                return false;

            return true;
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            var result = await _commentRepository.DeleteAsync(commentId);
            return result;
        }

        public List<Comment>? GetAuctionComments(int auctionId)
        {
            return _commentRepository.Filter(x => x.AuctionId == auctionId);
        }

        public async Task<bool> UpdateComment(int commentId, Dictionary<string, string> body)
        {
            var comment = await _commentRepository.GetById(commentId);
            if (comment == null) 
                return false;

            comment.CommentContent = body["CommentContent"];
            var result = await _commentRepository.UpdateAsync(comment);

            return result;
        }
    }
}
