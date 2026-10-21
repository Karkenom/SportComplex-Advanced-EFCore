using System.Collections.Generic;

namespace SportComplexTemplate.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Навигационное свойство: связь «один ко многим»
        public List<Client> Clients { get; set; } = new List<Client>();
    }
}
