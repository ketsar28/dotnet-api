using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassicShopAPI.Entities;

/*
 * Purchase dan Product di set sebagai optional (?) : karena supaya yang dikirim itu id-nya saja, kalau tidak ditambahkan optional maka akan terkena validasi dan sifatnya required
 * 
 */

[Table(("trx_purchase_detail"))]
public class PurchaseDetail
{
    [Key, Column("id")] public Guid Id { get; set; }
    [Column("purchase_id")] public Guid  PurchaseId { get; set; }
    [Column("product_id")] public Guid ProductId { get; set; }
    [Column("qty")] public int Qty { get; set; }

    public virtual Purchase? Purchase { get; set; }
    public virtual Product? Product { get; set; }
}