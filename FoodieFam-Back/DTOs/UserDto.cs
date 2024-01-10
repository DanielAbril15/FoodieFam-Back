namespace FoodieFam_Back.DTOs
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
        public bool IsVerified { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
