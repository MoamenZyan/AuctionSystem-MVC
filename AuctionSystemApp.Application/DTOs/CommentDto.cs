using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string CommentContent { get; set; } = null!;
        public int UserId { get; set; }
        public int AuctionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; }
        public string UserPhoto { get; set; }

        public CommentDto(Comment comment)
        {
            Id = comment.Id;
            CommentContent = comment.CommentContent;
            CreatedAt = comment.CreatedAt;
            UserId = comment.UserId;
            AuctionId = comment.AuctionId;
            UserName = comment.User.Fname + " " + comment.User.Lname;
            UserPhoto = comment.User.PhotoPath;
        }
    }
}
