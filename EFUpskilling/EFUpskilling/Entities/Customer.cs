using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFUpskilling.Entities;
/*
 * annotation di java itu menggunakan a keong (@) atau at
 * anontation di C# kurung siku []
 */

[Table(name: "m_customer")]
public class Customer
{
 [Key, 
  Column(name:"id"), 
  DatabaseGenerated(DatabaseGeneratedOption.Identity)
 ]
 public int Id { get; set; }
 [Column(name:"customer_name", TypeName = "varchar(255)")]
 public string CustomerName { get; set; }
 [Column(name:"address", TypeName = "varchar(255)")]
 public string Address { get; set; }
 [Column(name:"mobile_phone", TypeName = "varchar(255)")]
 public string MobilePhone { get; set; }
 [Column(name:"email", TypeName = "varchar(255)")]
 public string Email { get; set; }
}