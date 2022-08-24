namespace InternBA.Models
{
    public class UserRefreshTokens
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
