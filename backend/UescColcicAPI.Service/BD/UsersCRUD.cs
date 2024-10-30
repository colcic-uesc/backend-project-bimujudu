using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace UescColcicAPI.Services.BD;

public class UsersCRUD : IUsersCRUD
{
    private UescColcicDBContext _context;
   public UsersCRUD(UescColcicDBContext context){
        _context = context;
   }
    public void Create(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(User entity)
    {   
        var user = this.Find(entity.UserId);
        if(user is not null){
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    public IEnumerable<User> ReadAll()
    {
        return _context.Users.Include(s => s.Students).Include(p => p.Professors);
    }

    public User? ReadById(int id)
    {
        var user = this.Find(id);
        return user;
    }

    public void Update(User entity)
    {
        var user = this.Find(entity.UserId);
        if(user is not null)
        {
            user.UserName = entity.UserName;
            user.Password = entity.Password;
            _context.SaveChanges();
        }
    }

    private User? Find(int id)
    {
        return _context.Users.Include(s => s.Students).Include(p => p.Professors).FirstOrDefault(x => x.UserId == id);
    }

}
