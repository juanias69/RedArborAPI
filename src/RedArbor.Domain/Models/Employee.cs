
namespace RedArbor.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public required string Email { get; set; }
        public string? Fax { get; set; }
        public string? Name { get; set; }
        public DateTime Lastlogin { get; set; }
        public required string Password { get; set; }
        public required int PortalId { get; set; }
        public required int RoleId { get; set; }
        public required int StatusId { get; set; }
        public string? Telephone { get; set; }
        public DateTime UpdatedOn { get; set; }
        public required string Username { get; set; }
    }
}
