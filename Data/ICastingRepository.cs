using System;
using System.Collections.Generic;
using System.Linq;
using Trululu.web.Entities;

namespace Trululu.web.Data
{
    public interface ICastingRepository
    {
        public IEnumerable<Casting> FindAll();

        public Casting FindById(int castingId);

        public IEnumerable<Casting> FindByCreator(int creatorId);

        public void Add(Casting casting);

        public void Remove(Casting casting);
    }
}
