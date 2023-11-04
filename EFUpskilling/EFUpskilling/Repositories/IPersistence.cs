namespace EFUpskilling.Repositories;

/*
 * interface ini mengelola :
 * - SaveChanges()
 * - BeginTransaction()
 * - Commit()
 * - Rollback()
 *
 * NOTE : 
 * file contextnya tidak perlu dipanggil di entry pointnya, karena itu sudah ada di repository filenya. dan SaveChanges() method itu ada di service class. jadi ketika kita ingin melakukan SaveChanges(), tidak perlu memanggil DbContextnya lagi
 *
 */

public interface IPersistence
{
    void SaveChanges();
    void BeginTransaction();
    void Commit();
    void Rollback();
}