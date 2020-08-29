using System;
using System.Collections.Generic;
using System.Linq;
using Trululu.web.Entities;

namespace Trululu.web.Data
{
    public class CastingRepository : ICastingRepository
    {
        private TruluDbContext context = new TruluDbContext();

        public IEnumerable<Casting> FindAll()
        {
            return context.Castings.ToList();
        }

        public Casting FindById(int castingId)
        {
            return context.Castings.FirstOrDefault(c => c.Id == castingId);
        }

        public IEnumerable<Casting> FindByCreator(int creatorId)
        {
            return
                context.Castings
                .Where(c => c.CreatorId == creatorId)
                .ToList();
        }

        public void Add(Casting casting)
        {
            context.Castings.Add(casting);
            context.SaveChanges();
        }

        public void Remove(Casting casting)
        {
            context.Castings.Remove(casting);
            context.SaveChanges();
        }
    }
}
