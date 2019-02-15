using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WissenMVC.Data;
using WissenMVC.Model;
using WissenMVC.Service.Services;

namespace WissenMVC.Service
{
    public class PostService:IPostService
    {
        private readonly IRepository<Post> repository;
        public PostService()
        {
            this.repository = repository;
        }
        public void Delete(int id)
        {
            var postToDelete = repository.Find(id);
            if (postToDelete != null)
            {
                repository.Delete(postToDelete);

            }
        }

        public Post Find(int id)
        {
            return repository.Find(id);
        }


        public Post Find(Expression<Func<Post, bool>> where)
        {
            return repository.Find(where);
        }

        public Post FindByName(string name)
        {
            return repository.Find(r => r.Title.Contains(name));
        }

        public IEnumerable<Post> GetAll()
        {
            return repository.GetAll(r => true);
        }

        public IEnumerable<Post> GetAll(Expression<Func<Post, bool>> where)
        {
            return repository.GetAll(where);
        }

        public void Insert(Post post)
        {
            repository.Insert(post);
        }

        public void Update(Post post)
        {
            repository.Update(post);
        }
    }
}
