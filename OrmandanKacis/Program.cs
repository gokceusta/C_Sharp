using System;

class Program
{
    static int oyuncuHP = 100;
    static int oyuncuGuc = 10;
    static int seviye = 1;
    static int xp = 0;

    static void Main()
    {
        Console.WriteLine("=== KARANLIK ORMAN RPG ===");
        Console.WriteLine("Bir karakter seçin:");
        Console.WriteLine("1. Savaşçı (Yüksek HP, orta saldırı)");
        Console.WriteLine("2. Büyücü (Düşük HP, yüksek saldırı)");
        Console.WriteLine("3. Hırsız (Dengeli karakter)");

        Console.Write("Seçiminizi yapın (1, 2, 3): ");
        string secim = Console.ReadLine();

        switch (secim)
        {
            case "1":
                oyuncuHP = 120;
                oyuncuGuc = 12;
                Console.WriteLine("\nSavaşçı seçildi! Dayanıklısın ama saldırı gücün orta.");
                break;
            case "2":
                oyuncuHP = 80;
                oyuncuGuc = 15;
                Console.WriteLine("\nBüyücü seçildi! Güçlü büyüler yapabilirsin ama dayanıklılığın düşük.");
                break;
            case "3":
                oyuncuHP = 100;
                oyuncuGuc = 10;
                Console.WriteLine("\nHırsız seçildi! Dengeli bir karakterin var.");
                break;
            default:
                Console.WriteLine("Geçersiz seçim! Varsayılan olarak Hırsız seçildi.");
                break;
        }

        Console.WriteLine("\nMacera başlıyor...");
        Console.WriteLine("");
        Macera();
    }

    static void Macera()
    {
        while (oyuncuHP > 0)
        {
            Console.WriteLine("\nOrmanda ilerliyorsun...");
            System.Threading.Thread.Sleep(1000);

            Random rnd = new Random();
            int dusmanTuru = rnd.Next(1, 4); // 1: Kurt, 2: Goblin, 3: Ork
            int dusmanHP = 0, dusmanGuc = 0;
            string dusmanAdi = "";

            switch (dusmanTuru)
            {
                case 1:
                    dusmanAdi = "Vahşi Kurt";
                    dusmanHP = 40;
                    dusmanGuc = 5;
                    break;
                case 2:
                    dusmanAdi = "Sinsi Goblin";
                    dusmanHP = 60;
                    dusmanGuc = 8;
                    break;
                case 3:
                    dusmanAdi = "Güçlü Ork";
                    dusmanHP = 80;
                    dusmanGuc = 12;
                    break;
            }

            Console.WriteLine($"Bir {dusmanAdi} ile karşılaştın! (HP: {dusmanHP}, Güç: {dusmanGuc})");
            Console.WriteLine("");

            while (dusmanHP > 0 && oyuncuHP > 0)
            {
                Console.WriteLine("\nNe yapmak istiyorsun?");
                Console.WriteLine("1. Saldır");
                Console.WriteLine("2. Kaç");

                Console.Write("Seçiminiz: ");
                string savasSecim = Console.ReadLine();

                if (savasSecim == "1")
                {
                    int oyuncuHasar = rnd.Next(oyuncuGuc - 2, oyuncuGuc + 2);
                    int dusmanHasar = rnd.Next(dusmanGuc - 2, dusmanGuc + 2);

                    dusmanHP -= oyuncuHasar;
                    Console.WriteLine("");
                    Console.WriteLine($"Düşmana {oyuncuHasar} hasar verdin! (Düşman HP: {dusmanHP})");

                    if (dusmanHP > 0)
                    {
                        oyuncuHP -= dusmanHasar;
                        Console.WriteLine("");
                        Console.WriteLine($"{dusmanAdi} sana {dusmanHasar} hasar verdi! (Senin HP: {oyuncuHP})");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Tebrikler! {dusmanAdi} yenildi.");
                        xp += 10;
                        SeviyeKontrol();
                    }
                }
                else if (savasSecim == "2")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Kaçmaya çalıştın...");
                    if (rnd.Next(1, 3) == 1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Kaçmayı başardın!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"{dusmanAdi} kaçmanı engelledi!");
                        oyuncuHP -= dusmanGuc;
                        Console.WriteLine("");
                        Console.WriteLine($"Sana {dusmanGuc} hasar verdi! (Senin HP: {oyuncuHP})");
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Geçersiz giriş! Tur geçildi.");
                }
            }

            if (oyuncuHP <= 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Öldün! Oyun bitti.");
                return;
            }

            if (seviye >= 3)
            {
                Console.WriteLine("");
                Console.WriteLine("\nKöye ulaştın ve zindanı tamamladın! Tebrikler, kazandın!");
                return;
            }
        }
    }

    static void SeviyeKontrol()
    {
        if (xp >= seviye * 20)
        {
            seviye++;
            oyuncuGuc += 2;
            oyuncuHP += 20;
            Console.WriteLine("");
            Console.WriteLine($"\nSeviye atladın! Yeni seviye: {seviye}");
            Console.WriteLine("");
            Console.WriteLine($"HP ve Güç arttı! (Yeni HP: {oyuncuHP}, Yeni Güç: {oyuncuGuc})");
        }
    }
}
