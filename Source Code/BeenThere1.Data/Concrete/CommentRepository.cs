using System;
using BeenThere1.Data.Abstract;
using BeenThere1.Entity;

namespace BeenThere1.Data.Concrete
{
    public class CommentRepository: GenericRepository<Comment, BTContext>, ICommentRepository
    {
        public CommentRepository()
        {
        }
    }
}
