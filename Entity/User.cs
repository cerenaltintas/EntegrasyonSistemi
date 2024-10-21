namespace EntegrasyonSistemi.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int BornYear { get; set; }

    }
}
