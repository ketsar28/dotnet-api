using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassicShopAPI.Entities;

/*
 * virtual ini sebagai penanda object relasi antara :
 * one to one, one to many
 *
 * jadi kalau ada attribute yang memiliki relasi ke entity/model lain itu ditambahkan key : virtual
 *
 * kalau di C# relasi itu ditandai langsung object :
 * - one to many : List<>/ICollection<>
 * - one to one / many to one : langsung objectnya/classnya tidak ada tambahan apapun. tergantung idnya dimana
 */

[Table(name:"m_purchase")]
public class Purchase
{
    [Key, Column("id")] public Guid Id { get; set; }

    [Column("trans_date")] public DateTime TransDate { get; set; }
    [Column("user_id")] public Guid UserId { get; set; }

    public virtual User? User { get; set; }
    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
}