using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.Business.Abstract
{
    public interface ICommentService
    {
        Comment GetById(int id);

        List<Comment> GetAll();

        void Create(Comment entity);

        void Update(Comment entity);

        void Delete(Comment entity);
    }
}
