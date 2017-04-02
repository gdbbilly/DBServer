using System;

namespace dbtest.Entities
{
    /// <summary>
    /// Entidade Restaurante
    /// </summary>
    public class RestaurantEntity
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public bool VotedInWeek { get; set; }

        public DateTime DateVoted { get; set; }

        public int Votes { get; set; }
    }
}
