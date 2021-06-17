using Microsoft.AspNetCore.Mvc;
using RestWithASP.Net5.Context;
using RestWithASP.Net5.Model;
using RestWithASP.Net5.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP.Net5.Repository.Implementations
{
    public class BooksRepositoryImplementation : IBooksRepository
    {
        private readonly MySQLContext _context;

        public BooksRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        public IEnumerable<Books> FindAll()
        {
            return _context.Books.ToList();
        }

        public Books FindById(long Id)
        {
            return _context.Books.SingleOrDefault(b => b.Equals(Id));
        }
        public Books Create(Books books)
        {
            try
            {
                _context.Add(books);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return books;
        }
        public Books Update(Books books)
        {
            if (!Exists(books.Id)) return null;

            var result = _context.Books.SingleOrDefault(b => b.Id.Equals(books.Id));

            if(books != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(books);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
            return books;
        }

        public void Delete(long Id)
        {
            var result = _context.Books.SingleOrDefault(b => b.Id.Equals(Id));

            if(result != null)
            {
                try
                {
                    _context.Remove(result);
                    _context.SaveChanges()
;                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private bool Exists(long Id)
        {
            return _context.Books.Any(b => b.Id.Equals(Id));
        }
    }
}
