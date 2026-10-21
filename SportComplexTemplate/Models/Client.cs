namespace SportComplexTemplate.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }

        // Внешний ключ и навигационное свойство к Абонементу (Один ко многим)
        public int MembershipId { get; set; }
        public Membership? Membership { get; set; }

        // Навигационное свойство к Ключу шкафчика (Связь «один к одному»)
        public LockerKey? LockerKey { get; set; }
    }
}
