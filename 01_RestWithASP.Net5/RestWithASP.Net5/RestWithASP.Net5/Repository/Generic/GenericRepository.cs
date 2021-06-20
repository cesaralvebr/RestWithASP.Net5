using Microsoft.EntityFrameworkCore;
using RestWithASP.Net5.Context;
using RestWithASP.Net5.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.Net5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;

        private DbSet<T> dataset;

        public GenericRepository(MySQLContext mySQLContext)
        {
            _context = mySQLContext;
            dataset = _context.Set<T>();
        }

        public IEnumerable<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long Id)
        {
            return dataset.SingleOrDefault(t => t.Id.Equals(Id));
        }


        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            var _result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (_result != null)
            {
                try
                {
                    dataset.Update(_result);
                    _context.SaveChanges();
                    return _result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
    
        public void Delete(long Id)
        {

            var _result = dataset.SingleOrDefault(p => p.Id.Equals(Id));


            if (_result != null)
            {
                try
                {
                    dataset.Remove(_result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
