﻿namespace View.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public int DreamId { get; set; }

        public CommentViewModel(int id, int userId, string message, int dreamId)
        {
            Id = id;
            UserId = userId;
            Message = message;
            DreamId = dreamId;
        }

        public CommentViewModel(int id, int userId, string message)
        {
            Id = id;
            UserId = userId;
            Message = message;
        }
    }
}
