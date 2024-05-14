using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task  AddAsync(Actor actor)
        {
            // Add the provided actor object to the DbSet of actors in the DbContext
            await _context.Actors.AddAsync(actor);

            // Save the changes to the database
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result =await _context.Actors.ToListAsync();
            return result;
        }

        

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n=>n.Id==id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }
}
