/*
 * File: Comment.cs
 * Namespace: Adoptapal.Business.Definitions
 * 
 * Description:
 * This file defines the "Comment" entity class, representing comments on a message board,
 * with properties including text, post time, associated post, and associated user.
 * 
 */

namespace Adoptapal.Business.Definitions
{
    /// <summary>
    /// Represents a comment on a message board.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the comment.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the text content of the comment.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the time when the comment was posted.
        /// </summary>
        public DateTime? PostTime { get; set; }

        /// <summary>
        /// Gets or sets the message board post associated with the comment.
        /// </summary>
        public MessageBoard? Post { get; set; }

        /// <summary>
        /// Gets or sets the user who posted the comment.
        /// </summary>
        public User? User { get; set; }
    }
}
