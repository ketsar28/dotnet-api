namespace ClassicShopAPI;

public class Notes
{
    /*
     * Clean Architecture yang dikasih hanya 1 project bukan multi project
     *
     * middleware :
     * - seperti express, jadi sebelum request ke http akan masuk ke aplikasi terlebih dahulu. lalu sebelum request sampai ke controller akan diberhentikan terlebih dahulu. jadi kita bisa selipkan tambahan code sebelum masuk ke controller, ini yang disebut middleware
     *
     * appSetting.json :
     * digunakan untuk menyimpan data berupa konfigurasi, baik itu konfigurasi database ataupun kita juga bisa menyimpan jwt secret difile tersebut, namun kurang secure. jadi bisa dibuat option sendiri. jadi secara otomatis file Program.cs sudah nge-config file appSetting.json
     *
     * weatherForecast.cs :
     * merupakan model yang disediakan default sama .NET API nya
     */
}