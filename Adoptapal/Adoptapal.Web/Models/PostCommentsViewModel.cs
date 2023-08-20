namespace Adoptapal.Web.Models
{
    public class PostCommentsViewModel
    {
        public IEnumerable<Adoptapal.Business.Definitions.MessageBoard> MessageBoards { get; set; }
        public Adoptapal.Business.Definitions.MessageBoard MessageBoard { get; set; }
        public IEnumerable<Adoptapal.Business.Definitions.Comment> Comments { get; set; }
        public Adoptapal.Business.Definitions.Comment Comment { get; set; }


    }
}
