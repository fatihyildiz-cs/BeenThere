using System;
using System.Collections.Generic;
using BeenThere1.Business.Abstract;
using BeenThere1.Data.Abstract;
using BeenThere1.Entity;

namespace BeenThere1.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentRepository _CommentRepository;

        public CommentManager(ICommentRepository commentRepository)
        {
            _CommentRepository = commentRepository;
        }

        public void Create(Comment entity)
        {
            _CommentRepository.Create(entity);
        }

        public void Delete(Comment entity)
        {
            _CommentRepository.Delete(entity);
        }

        public List<Comment> GetAll()
        {
            return _CommentRepository.GetAll();
        }

        public Comment GetById(int id)
        {
            return _CommentRepository.GetById(id);
        }

        public void Update(Comment entity)
        {
            _CommentRepository.Update(entity);
        }
    }
}
