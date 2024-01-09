using Microsoft.EntityFrameworkCore;
using MyNewWebSite.AccessLayer.Context;
using MyNewWebSite.AccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyNewWebSite.Core.Interface;

    public interface IRepositoryBase<T> 
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindByCondotion(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }


public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected MyDatabaseContext db {  get; set; }
    public RepositoryBase(MyDatabaseContext db)
    {
         this.db = db;
    }
    public void Create(T entity) => db.Set<T>().Add(entity);
   

    public void Delete(T entity) => db.Set<T>().Remove(entity);

    public IQueryable<T> FindByCondotion(Expression<Func<T, bool>> expression) => 
        db.Set<T>().Where(expression).AsNoTracking();

    public IQueryable<T> GetAll() => db.Set<T>().AsNoTracking();

    public void Update(T entity) => db.Set<T>().Update(entity);
}

public interface IOwnerRepository : IRepositoryBase<User>
{

}

public interface IAccountRepository : IRepositoryBase<Role>
{

}

public class OwnerRepository : RepositoryBase<User>, IOwnerRepository
{
    public OwnerRepository(MyDatabaseContext context) : base(context) 
    {
        
    }
}

public class AccountRepository : RepositoryBase<Role>, IAccountRepository
{
    public AccountRepository(MyDatabaseContext context) : base (context) 
    {
        
    }
}

public interface IRepositoryWrapper
{
    IOwnerRepository Owner { get;}
    IAccountRepository Account { get;}
    void Save();
}
public class RepositoryWrapper : IRepositoryWrapper
{
    private MyDatabaseContext _context;
    private IOwnerRepository _ownerRepository;
    private IAccountRepository _accountRepository;

    public IOwnerRepository Owner
    {
        get
        {
            if (_ownerRepository == null)
            {
                _ownerRepository = new OwnerRepository(_context);
            }
            return _ownerRepository;
        }
    }

    public IAccountRepository Account
    {
        get
        {
            if (_accountRepository == null)
            {
                _accountRepository = new AccountRepository(_context);
            }
            return _accountRepository;
        }
    }

    public RepositoryWrapper(MyDatabaseContext context)
    {
        _context = context;

    }
    public void Save()
    {
        _context.SaveChanges();
    }
}