using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFUpskilling.Entities;

[Table(name:"m_user")]
public class User
{
    [Key, Column(name:"id")] public Guid Id { get; set; }
    
    [Column(name:"customer_name", TypeName = "varchar(255)")] public string CustomerName { get; set; }
    
    [Column(name:"address", TypeName = "varchar(255)")] public string Address { get; set; }
    
    [Column(name:"mobile_phone", TypeName = "varchar(255)")] public string MobilePhone { get; set; }
    
    [Column(name:"email", TypeName = "varchar(255)")] public string Email { get; set; }
}