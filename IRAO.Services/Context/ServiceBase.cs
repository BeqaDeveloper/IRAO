using IRAO.Domain.Entities;
using IRAO.Domain.Interfaces;
using IRAO.Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRAO.Services.Context
{
    public class ServiceBase<T, K> : IService<T>
   where T : class, new()
   where K : IRepository<T>
    {

        protected IUnitOfWork _context;
        protected K _repository;

        public ServiceBase(IUnitOfWork context, K repository)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (repository == null) throw new ArgumentNullException("repository");

            _context = context;
            _repository = repository;
        }

        public T Fetch(long id)
        {
            return _repository.Fetch(id);
        }

        public IEnumerable<T> Set()
        {
            return _repository.Set();
        }

        public void Save(T entity)
        {
            _repository.Save(entity);
            _context.Commit();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
            _context.Commit();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _context.Commit();
        }
       
    }
}
