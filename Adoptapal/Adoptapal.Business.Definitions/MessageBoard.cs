/*
 * File: MessageBoard.cs
 * Namespace: Adoptapal.Business.Definitions
 * 
 * Description:
 * This file defines the "MessageBoard" entity class, representing message board posts,
 * with properties including title, text content, post time, associated user, and potentially
 * associated comments.
 * 
 */

namespace Adoptapal.Business.Definitions
{
    /// <summary>
    /// Represents a message board post.
    /// </summary>
    public class MessageBoard
    {
        /// <summary>
        /// Gets or sets the unique identifier for the message board post.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the message board post.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the text content of the message board post.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the time when the message board post was created.
        /// </summary>
        public DateTime? PostTime { get; set; }

        /// <summary>
        /// Gets or sets the user who created the message board post.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the comments associated with the message board post.
        /// </summary>
    }
}
