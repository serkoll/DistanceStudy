namespace DbRepository.Classes.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string GroupPermission { get; set; }
        public string GroupIn { get; set; }
    }
}