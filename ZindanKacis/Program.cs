using System;

class Program
{
    static bool anahtarVar = false; // Oyuncunun anahtarı olup olmadığını takip eder

    static void Main()
    {
        Console.WriteLine("=== Zindan Kaçışı ===");
        Console.WriteLine("Karanlık bir hücrede uyandın. Önünde iki seçenek var.");
        Console.WriteLine("1. Kapıyı aç");
        Console.WriteLine("2. Gizli geçitten geç");
        Console.WriteLine("3. Çıkış ");

        Console.WriteLine("----------------------------------------------------------------");
        while (true)
        {        
            Console.Write("Seçiminizi yapın (1 veya 2): ");
            string secim = Console.ReadLine();
            
            if (secim == "1")
            {
                KapıyıAç();
                break;
            }
            else if (secim == "2")
            {
                GizliGeçit();
                break;
            }
            else if (secim == "3")
            {
                Console.WriteLine("Oyundan çıkış yaptınız.");
                break;
            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Tekrar deneyin.");
            }
        }
    }

    static void KapıyıAç()
    {
        Console.WriteLine("\nKapıyı açtın ve bir muhafız karşına çıktı!");
        Console.WriteLine("Ne yapacaksın?");
        Console.WriteLine("1. Dövüş");
        Console.WriteLine("2. Kaç");

        Console.Write("Seçiminizi yapın (1 veya 2): ");
        string secim = Console.ReadLine();

        if (secim == "1")
        {
            MuhafızlaDövüş();
        }
        else if (secim == "2")
        {
            Console.WriteLine("Kaçmaya çalıştın ama muhafız seni yakaladı! Oyun bitti.");
        }

        else
        {
            Console.WriteLine("Geçersiz seçim! Muhafız seni yakaladı! Oyun bitti.");
        }
    }

    static void MuhafızlaDövüş()
    {
        Random rnd = new Random();
        int sans = rnd.Next(1, 3); // 1 veya 2 üretir (şans faktörü)

        if (sans == 1)
        {
            Console.WriteLine("Muhafızı yendin ve kaçtın!");
            CikisKapisi();
        }
        else
        {
            Console.WriteLine("Muhafız seni yendi! Oyun bitti.");
        }
    }

    static void GizliGeçit()
    {
        Console.WriteLine("\nGizli bir geçitten geçtin ve bir sandık buldun.");
        Console.WriteLine("1. Sandığı aç");
        Console.WriteLine("2. Yoluna devam et");


        Console.Write("Seçiminizi yapın (1 veya 2): ");
        string secim = Console.ReadLine();

        if (secim == "1")
        {
            SandıkAç();
            
        }
        else if (secim == "2")
        {
            Console.WriteLine("Sandığı açmadan ilerledin. Çıkış kapısına ulaştın ama kilitli!");
            CikisKapisi();
        }
                
        else
        {
            Console.WriteLine("Geçersiz seçim! Oyun bitti.");
        }
    }

    static void SandıkAç()
    {
        Random rnd = new Random();
        int sans = rnd.Next(1, 3); // 1 veya 2 üretir

        if (sans == 1)
        {
            Console.WriteLine("Sandığın içinde bir ANAHTAR buldun!");
            anahtarVar = true;
        }
        else
        {
            Console.WriteLine("Sandık bir tuzak çıktı! Oyun bitti.");
            return;
        }

        CikisKapisi();
    }

    static void CikisKapisi()
    {
        Console.WriteLine("\nBüyük çıkış kapısına ulaştın. Ancak kapı kilitli!");

        if (anahtarVar)
        {
            Console.WriteLine("Anahtarı kullandın ve kapıyı açtın! Zindandan kaçtın! KAZANDIN!");
        }
        else
        {
            Console.WriteLine("Anahtarın yok! Kapıyı açamıyorsun. Oyun bitti.");
        }
    }
}

        
        
        
        
        
        
 