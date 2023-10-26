using System;
//Deneme12
class Kitap
{
    public string Ad { get; set; }
    public string Yazar { get; set; }
    public string YayinEvi { get; set; }
    public int YayinYili { get; set; }
    public bool OduncDurumu { get; set; }
}

class Kutuphane
{
    private Kitap[] kitaplar;

    public Kutuphane(int kapasite)
    {
        kitaplar = new Kitap[kapasite];
    }

    public void KitapEkle(Kitap yeniKitap)
    {
        for (int i = 0; i < kitaplar.Length; i++)
        {
            if (kitaplar[i] == null)
            {
                kitaplar[i] = yeniKitap;
                Console.WriteLine("Yeni kitap eklendi: " + yeniKitap.Ad);
                return;
            }
        }
        Console.WriteLine("Kütüphane dolu, kitap eklenemedi.");
    }

    public void KitaplariListele()
    {
        Console.WriteLine("Kütüphanedeki Kitaplar:");
        foreach (var kitap in kitaplar)
        {
            if (kitap != null)
            {
                Console.WriteLine($"Ad: {kitap.Ad}, Yazar: {kitap.Yazar}, Yayın Evi: {kitap.YayinEvi}, Yayın Yılı: {kitap.YayinYili}, Ödünç Durumu: {(kitap.OduncDurumu ? "Ödünç Alındı" : "Kütüphanede")}");
            }
        }
    }

    public void KitapOduncVer(string kitapAdi)
    {
        foreach (var kitap in kitaplar)
        {
            if (kitap != null && kitap.Ad.Equals(kitapAdi, StringComparison.OrdinalIgnoreCase) && !kitap.OduncDurumu)
            {
                kitap.OduncDurumu = true;
                Console.WriteLine($"{kitap.Ad} adlı kitap ödünç verildi.");
                return;
            }
        }
        Console.WriteLine($"{kitapAdi} adlı kitap bulunamadı veya ödünç verilemez.");
    }

    public void KitapGeriAl(string kitapAdi)
    {
        foreach (var kitap in kitaplar)
        {
            if (kitap != null && kitap.Ad.Equals(kitapAdi, StringComparison.OrdinalIgnoreCase) && kitap.OduncDurumu)
            {
                kitap.OduncDurumu = false;
                Console.WriteLine($"{kitap.Ad} adlı kitap geri alındı.");
                return;
            }
        }
        Console.WriteLine($"{kitapAdi} adlı kitap bulunamadı veya zaten kütüphanede.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Kutuphane kutuphane = new Kutuphane(100);

        Kitap kitap1 = new Kitap { Ad = "Suç ve Ceza", Yazar = "Fyodor Dostoyevski", YayinEvi = "Yayınevi 1", YayinYili = 1866, OduncDurumu = false };
        Kitap kitap2 = new Kitap { Ad = "1984", Yazar = "George Orwell", YayinEvi = "Yayınevi 2", YayinYili = 1949, OduncDurumu = false };

        kutuphane.KitapEkle(kitap1);
        kutuphane.KitapEkle(kitap2);

        kutuphane.KitaplariListele();

        kutuphane.KitapOduncVer("Suç ve Ceza");
        kutuphane.KitapOduncVer("Beyaz Diş"); // Örnek olarak olmayan bir kitap ödünç verilmeye çalışılıyor.

        kutuphane.KitaplariListele();

        kutuphane.KitapGeriAl("Suç ve Ceza");

        kutuphane.KitaplariListele();
    }
}
