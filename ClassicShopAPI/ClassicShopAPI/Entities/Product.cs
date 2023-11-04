using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassicShopAPI.Entities;

[Table(name:"m_product")]
public class Product
{
    [Key, Column(name:"id")]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(10)]
    [Column(name:"product_name", TypeName = "varchar(255)")]
    public string ProductName { get; set; }
    
    [Column(name:"product_price", TypeName = "decimal(20)")]
    public long ProductPrice { get; set; }
    
    [Column(name:"stock", TypeName = "int(11)")]
    public int Stock { get; set; }
}