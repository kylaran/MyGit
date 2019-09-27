using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
   public class EFGameRepository : IGameRepository
    {
        readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Game> Games
        {
            get { return context.Games; }
        }

    }
}
