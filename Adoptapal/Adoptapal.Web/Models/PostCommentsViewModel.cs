/*
 * File: PostCommentsViewModel.cs
 * Namespace: Adoptapal.Web.Models
 * 
 * Description:
 * This file contains the implementation of the PostCommentsViewModel class, which is used
 * to display details about a message board post and its associated comments.
 * 
 */

namespace Adoptapal.Web.Models
{
    public class PostCommentsViewModel
    {
        // Represents a collection of message board posts
        public IEnumerable<Adoptapal.Business.Definitions.MessageBoard> MessageBoards { get; set; }

        // Represents a single message board post
        public Adoptapal.Business.Definitions.MessageBoard MessageBoard { get; set; }

        // Represents a collection of comments associated with the message board post
        public IEnumerable<Adoptapal.Business.Definitions.Comment> Comments { get; set; }

        // Represents a single comment
        public Adoptapal.Business.Definitions.Comment Comment { get; set; }
    }
}
