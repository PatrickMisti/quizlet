using Microsoft.EntityFrameworkCore;
using quizlet_back.Repository.DbModel.Base;

namespace quizlet_back.Repository
{
    public class Repository<T>: IRepository<T> where T : class,new()
    {

        public async Task<bool> Create(T entity)
        {
            await using var db = new DbDatabase();
            await db.Set<T>().AddAsync(entity);

            return await db.SaveChangesAsync() > 0;
        }

        public async Task<int> Update(T entity)
        {
            await using var db = new DbDatabase();
            db.Set<T>().Update(entity);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            await using var db = new DbDatabase();
            db.Set<T>().Remove(entity);

            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteById(int entityId)
        {
            await using var db = new DbDatabase();
            var itemList = await GetAll(db);
            var search = itemList.FirstOrDefault(item => (item as BaseEntity).Id == entityId);

            if (search == null)
                return -1;

            db.Set<T>().Remove(search);
            return await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            await using var db = new DbDatabase();
            return await db.Set<T>().ToListAsync();
        }

        private async Task<IEnumerable<T>> GetAll(DbDatabase db)
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            await using var db = new DbDatabase();
            var itemList = await GetAll(db);
            var search = itemList.FirstOrDefault(item => (item as BaseEntity).Id == id);

            return search;
        }
    }
}
