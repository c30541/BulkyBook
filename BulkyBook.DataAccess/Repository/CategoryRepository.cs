using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public void Update(ApplicationUser applicationUser)
        //{
        //    var objFormDb = _db.Categories.FirstOrDefault(s => s.Id == applicationUser.Id);
        //    if (objFormDb != null)
        //    {
        //        objFormDb.Name = applicationUser.Name;
        //    }
        //}
    }
}
