using AuctionSystemApp.Domain.Entities;
using Ganss.Xss;

namespace AuctionSystemApp.Domain.Factories
{
    public class CommentFactory
    {
        static HtmlSanitizer htmlSanitizer = new HtmlSanitizer();
        public static Comment CreateComment(Dictionary<string, string> body)
        {
            Comment comment = new Comment
            {
                AuctionId = Convert.ToInt32(body["AuctionId"]),
                UserId = Convert.ToInt32(body["UserId"]),
                CommentContent = htmlSanitizer.Sanitize(body["CommentContent"]),
                CreatedAt = DateTime.Now
            };
            return comment;
        }
    }
}
