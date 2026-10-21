namespace SportComplexTemplate.Models
{
    public class LockerKey
    {
        public int Id { get; set; }
        public string KeyNumber { get; set; } = string.Empty;

        // Внешний ключ и навигационное свойство к Клиенту (Связь «один к одному»)
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
