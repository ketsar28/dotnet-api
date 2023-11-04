namespace EFUpskilling.efcore;

/*
 * EF (Entity Framework) : digunakan untuk mempermudah dalam pembuatan CRUD. ini seperti Spring Data JPA di Java
 *
 * Dependency yang dibutuhkan :
 * - Microsoft.EntityFrameworkCore
 * - Microsoft.EntityFrameworkCore.Tools
 * - Microsoft.EntityFrameworkCore.Design (dipakai saat menggunakan DI (Dependency Injection))
 * - Mysql.Data.EntityFrameworkCore
 *
 * code first : model -> migrate to database
 * database first : (misal database sudah ada) entity framework akan meng-generate model" yang ada di database
 *
 * kalau EF : ga bisa auto migration, jadi harus klik/ketikan console (kekurangan). beda seperti springboot, ketika di run auto terbuat table"nya
 *
 * annotation di java itu menggunakan a keong (@) atau at
 * annotation di C# kurung siku []
 *
 * di Rider untuk melakukan migrate ada plugin yang dapat digunakan apabila tidak ingin manual menggunakan terminal :
 * menggunakan Entity Framework Core UI : untuk melakukan migrate database
 *
 * proses/stage :
 * 1. entity/model -> 2. repository -> install ef core di terminal untuk migration (apabila belum ada) -> melakukan migration ke db diterminal
 */

public class EfCore
{
 
}