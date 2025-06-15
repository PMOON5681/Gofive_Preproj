using Microsoft.EntityFrameworkCore;
using UserManage.API.Data;
using UserManage.API.Models.Domain;
using UserManage.API.Repositories.Interface;

namespace UserManage.API.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(Guid id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.id == id);
            if (existingUser is null)
                return null;
            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetById(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.id == user.id);

            if (existingUser != null) 
            {
                dbContext.Entry(existingUser).CurrentValues.SetValues(user);
                await dbContext.SaveChangesAsync();
                return user;
            }

            return null;
        }
    }
}
