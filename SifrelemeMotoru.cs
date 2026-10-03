using System;
using System.Linq;
using System.Text;

public static class SifrelemeMotoru
{
    // Türkçedeki 29 harfi sabit bir sırada tutuyoruz
    public const string Alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";

    // Metni temizleme: Boşlukları siler ve her şeyi büyük harfe çevirir
    public static string Temizle(string metin)
    {
        return new string(metin.ToUpper().Where(c => Alfabe.Contains(c)).ToArray());
    }

    public static string KaydirmaliSifrele(string metin, int anahtar)
    {
        string temizMetin = Temizle(metin);
        string sonuc = "";

        foreach (char harf in temizMetin)
        {
            int siradakiIndex = Alfabe.IndexOf(harf);
            // Formül: (Mevcut İndis + Kaydırma Miktarı) % 29
            int yeniIndex = (siradakiIndex + anahtar) % Alfabe.Length;
            sonuc += Alfabe[yeniIndex];
        }
        return sonuc;
    }

    public static string KaydirmaliCoz(string sifreliMetin, int anahtar)
    {
        string sonuc = "";

        foreach (char harf in sifreliMetin)
        {
            int siradakiIndex = Alfabe.IndexOf(harf);
            // Formül: (Mevcut İndis - Kaydırma Miktarı + 29) % 29
            // +29 eklememizin sebebi sonucun negatif çıkmasını önlemektir.
            int yeniIndex = (siradakiIndex - anahtar + Alfabe.Length) % Alfabe.Length;
            sonuc += Alfabe[yeniIndex];
        }
        return sonuc;
    }
    public static string ZigzagSifrele(string metin, int satirSayisi)
    {
        if (satirSayisi <= 1) return metin;
        string temizMetin = Temizle(metin);
        string[] satirlar = new string[satirSayisi];

        int suankiSatir = 0;
        bool asagiGidiyor = false;

        foreach (char c in temizMetin)
        {
            satirlar[suankiSatir] += c;
            if (suankiSatir == 0 || suankiSatir == satirSayisi - 1) asagiGidiyor = !asagiGidiyor;
            suankiSatir += asagiGidiyor ? 1 : -1;
        }

        return string.Concat(satirlar);
    }

    public static string ZigzagCoz(string sifreliMetin, int satirSayisi)
    {
        if (satirSayisi <= 1) return sifreliMetin;
        int n = sifreliMetin.Length;
        char[] sonuc = new char[n];
        bool[] doluMu = new bool[n];
        int[] satirIndisleri = new int[n];

        int suankiSatir = 0;
        bool asagiGidiyor = false;

        // Önce zikzak desenini oluşturuyoruz (hangi karakter hangi satıra gelecek)
        for (int i = 0; i < n; i++)
        {
            satirIndisleri[i] = suankiSatir;
            if (suankiSatir == 0 || suankiSatir == satirSayisi - 1) asagiGidiyor = !asagiGidiyor;
            suankiSatir += asagiGidiyor ? 1 : -1;
        }

        int sayac = 0;
        for (int r = 0; r < satirSayisi; r++)
        {
            for (int i = 0; i < n; i++)
            {
                if (satirIndisleri[i] == r)
                {
                    sonuc[i] = sifreliMetin[sayac++];
                }
            }
        }
        return new string(sonuc);
    }
    public static int ModTers(int a, int m)
    {
        a = a % m;
        for (int x = 1; x < m; x++)
        {
            if ((a * x) % m == 1)
                return x;
        }
        return -1;
    }
    public static string DogrusalSifrele(string metin, int a, int b)
    {
        string temiz = Temizle(metin);
        string sonuc = "";

        foreach (char c in temiz)
        {
            int x = Alfabe.IndexOf(c);
            int yeniIndex = (a * x + b) % Alfabe.Length;
            sonuc += Alfabe[yeniIndex];
        }
        return sonuc;
    }
    public static string DogrusalCoz(string metin, int a, int b)
    {
        string sonuc = "";
        int aTers = ModTers(a, Alfabe.Length);

        if (aTers == -1)
            throw new Exception("a değeri 29 ile aralarında asal olmalı!");

        foreach (char c in metin)
        {
            int y = Alfabe.IndexOf(c);
            int yeniIndex = (aTers * (y - b + Alfabe.Length)) % Alfabe.Length;
            sonuc += Alfabe[yeniIndex];
        }
        return sonuc;
    }
    public static string PermutasyonSifrele(string metin, int blokBoyutu)
    {
        string temiz = Temizle(metin);

        if (blokBoyutu <= 1)
            return temiz;

        string sonuc = "";

        for (int i = 0; i < temiz.Length; i += blokBoyutu)
        {
            int kalan = Math.Min(blokBoyutu, temiz.Length - i);
            char[] blok = temiz.Substring(i, kalan).ToCharArray();
            Array.Reverse(blok); // bloğu ters çeviriyoruz
            sonuc += new string(blok);
        }

        return sonuc;
    }
    public static string PermutasyonCoz(string sifreliMetin, int blokBoyutu)
    {
        if (blokBoyutu <= 1)
            return sifreliMetin;

        string sonuc = "";

        for (int i = 0; i < sifreliMetin.Length; i += blokBoyutu)
        {
            int kalan = Math.Min(blokBoyutu, sifreliMetin.Length - i);
            char[] blok = sifreliMetin.Substring(i, kalan).ToCharArray();
            Array.Reverse(blok);
            sonuc += new string(blok);
        }

        return sonuc;
    }
    public static string RotaSifrele(string metin, int satir)
    {
        string temiz = Temizle(metin);
        int uzunluk = temiz.Length;

        int sutun = (int)Math.Ceiling((double)uzunluk / satir);

        char[,] matris = new char[satir, sutun];

        int index = 0;

        // Matrise satır satır doldur
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                if (index < uzunluk)
                    matris[i, j] = temiz[index++];
                else
                    matris[i, j] = 'X'; // eksik yerlere dolgu
            }
        }

        string sonuc = "";

        int top = 0, bottom = satir - 1;
        int left = 0, right = sutun - 1;

        while (top <= bottom && left <= right)
        {
            for (int i = left; i <= right; i++)
                sonuc += matris[top, i];
            top++;

            for (int i = top; i <= bottom; i++)
                sonuc += matris[i, right];
            right--;

            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                    sonuc += matris[bottom, i];
                bottom--;
            }

            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                    sonuc += matris[i, left];
                left++;
            }
        }

        return sonuc;
    }
    public static string RotaCoz(string sifreliMetin, int satir)
    {
        int uzunluk = sifreliMetin.Length;
        int sutun = (int)Math.Ceiling((double)uzunluk / satir);

        char[,] matris = new char[satir, sutun];

        int top = 0, bottom = satir - 1;
        int left = 0, right = sutun - 1;

        int index = 0;

        while (top <= bottom && left <= right)
        {
            for (int i = left; i <= right; i++)
                matris[top, i] = sifreliMetin[index++];
            top++;

            for (int i = top; i <= bottom; i++)
                matris[i, right] = sifreliMetin[index++];
            right--;

            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                    matris[bottom, i] = sifreliMetin[index++];
                bottom--;
            }

            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                    matris[i, left] = sifreliMetin[index++];
                left++;
            }
        }

        string sonuc = "";

        for (int i = 0; i < satir; i++)
            for (int j = 0; j < sutun; j++)
                sonuc += matris[i, j];

        return sonuc.TrimEnd('X');
    }
    public static string YeniAlfabeOlustur(string anahtarKelime)
    {
        anahtarKelime = Temizle(anahtarKelime);

        string yeniAlfabe = "";

        foreach (char c in anahtarKelime)
            if (!yeniAlfabe.Contains(c))
                yeniAlfabe += c;

        foreach (char c in Alfabe)
            if (!yeniAlfabe.Contains(c))
                yeniAlfabe += c;

        return yeniAlfabe;
    }
    public static string YerDegistirmeSifrele(string metin, string anahtarKelime)
    {
        string temiz = Temizle(metin);
        string yeniAlfabe = YeniAlfabeOlustur(anahtarKelime);

        string sonuc = "";

        foreach (char c in temiz)
        {
            int index = Alfabe.IndexOf(c);
            sonuc += yeniAlfabe[index];
        }

        return sonuc;
    }
    public static string YerDegistirmeCoz(string metin, string anahtarKelime)
    {
        string yeniAlfabe = YeniAlfabeOlustur(anahtarKelime);

        string sonuc = "";

        foreach (char c in metin)
        {
            int index = yeniAlfabe.IndexOf(c);
            sonuc += Alfabe[index];
        }

        return sonuc;
    }
    public static string SayiAnahtarliSifrele(string metin, int[] anahtar)
    {
        string temiz = Temizle(metin);
        string sonuc = "";

        for (int i = 0; i < temiz.Length; i++)
        {
            int kaydirma = anahtar[i % anahtar.Length];
            int index = Alfabe.IndexOf(temiz[i]);
            int yeniIndex = (index + kaydirma) % Alfabe.Length;
            sonuc += Alfabe[yeniIndex];
        }

        return sonuc;
    }
    public static string SayiAnahtarliCoz(string metin, int[] anahtar)
    {
        string sonuc = "";

        for (int i = 0; i < metin.Length; i++)
        {
            int kaydirma = anahtar[i % anahtar.Length];
            int index = Alfabe.IndexOf(metin[i]);
            int yeniIndex = (index - kaydirma + Alfabe.Length) % Alfabe.Length;
            sonuc += Alfabe[yeniIndex];
        }

        return sonuc;
    }
    // SifrelemeMotoru sınıfının içine en alta ekle
    public static string HillSifrele(string metin, int[] anahtar)
    {
        // anahtar dizisi 4 elemanlı olmalı (a, b, c, d gibi)
        string temiz = Temizle(metin);
        if (temiz.Length % 2 != 0) temiz += "X"; // Tekse sonuna dolgu ekle

        string sonuc = "";
        for (int i = 0; i < temiz.Length; i += 2)
        {
            int p1 = Alfabe.IndexOf(temiz[i]);
            int p2 = Alfabe.IndexOf(temiz[i + 1]);

            // C1 = (a*p1 + b*p2) mod 29
            // C2 = (c*p1 + d*p2) mod 29
            int c1 = (anahtar[0] * p1 + anahtar[1] * p2) % Alfabe.Length;
            int c2 = (anahtar[2] * p1 + anahtar[3] * p2) % Alfabe.Length;

            sonuc += Alfabe[c1];
            sonuc += Alfabe[c2];
        }
        return sonuc;
    }

    public static string HillCoz(string metin, int[] anahtar)
    {
        int n = Alfabe.Length;
        // Determinant hesabı: (ad - bc)
        int det = (anahtar[0] * anahtar[3] - anahtar[1] * anahtar[2]);

        // Modüler determinant (negatif çıkmaması için)
        int detMod = (det % n + n) % n;
        int detTers = ModTers(detMod, n);

        if (detTers == -1)
            throw new Exception("Bu matrisin tersi yok! Lütfen başka anahtar seçin.");

        // Ters Matris Elemanları: [d*detTers, -b*detTers, -c*detTers, a*detTers]
        int[] tersAnahtar = new int[4];
        tersAnahtar[0] = (anahtar[3] * detTers) % n;
        tersAnahtar[1] = ((-anahtar[1] * detTers) % n + n) % n;
        tersAnahtar[2] = ((-anahtar[2] * detTers) % n + n) % n;
        tersAnahtar[3] = (anahtar[0] * detTers) % n;

        string sonuc = "";
        for (int i = 0; i < metin.Length; i += 2)
        {
            int c1 = Alfabe.IndexOf(metin[i]);
            int c2 = Alfabe.IndexOf(metin[i + 1]);

            int p1 = (tersAnahtar[0] * c1 + tersAnahtar[1] * c2) % n;
            int p2 = (tersAnahtar[2] * c1 + tersAnahtar[3] * c2) % n;

            sonuc += Alfabe[p1];
            sonuc += Alfabe[p2];
        }
        return sonuc;
    }
    // SifrelemeMotoru içine eklenecek yardımcı karakter
    private const string Alfabe30 = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ*"; // 30 Karakter (6x5 Matris için)

    public static string DortKareSifrele(string metin, string anahtar1, string anahtar2)
    {
        string temiz = Temizle(metin);
        if (temiz.Length % 2 != 0) temiz += "X"; // Çift olması için dolgu

        // Matrisleri oluştur (Sol Üst ve Sağ Alt standart, Sağ Üst ve Sol Alt anahtarlı)
        string q1 = Alfabe30; // Standart
        string q4 = Alfabe30; // Standart
        string q2 = YeniAlfabeOlustur30(anahtar1); // Sağ Üst
        string q3 = YeniAlfabeOlustur30(anahtar2); // Sol Alt

        string sonuc = "";
        for (int i = 0; i < temiz.Length; i += 2)
        {
            int p1 = q1.IndexOf(temiz[i]);
            int p2 = q4.IndexOf(temiz[i + 1]);

            // Karakterlerin koordinatlarını bul (6 satır, 5 sütun)
            int r1 = p1 / 5, c1 = p1 % 5;
            int r2 = p2 / 5, c2 = p2 % 5;

            // Şifreleme: (r1, c2) ve (r2, c1) konumlarını kullan
            sonuc += q2[r1 * 5 + c2];
            sonuc += q3[r2 * 5 + c1];
        }
        return sonuc;
    }

    public static string DortKareCoz(string metin, string anahtar1, string anahtar2)
    {
        string q1 = Alfabe30;
        string q4 = Alfabe30;
        string q2 = YeniAlfabeOlustur30(anahtar1);
        string q3 = YeniAlfabeOlustur30(anahtar2);

        string sonuc = "";
        for (int i = 0; i < metin.Length; i += 2)
        {
            int p1 = q2.IndexOf(metin[i]);
            int p2 = q3.IndexOf(metin[i + 1]);

            int r1 = p1 / 5, c1 = p1 % 5;
            int r2 = p2 / 5, c2 = p2 % 5;

            sonuc += q1[r1 * 5 + c2];
            sonuc += q4[r2 * 5 + c1];
        }
        return sonuc;
    }

    // 30 karakterlik yeni alfabe oluşturucu
    private static string YeniAlfabeOlustur30(string anahtar)
    {
        anahtar = Temizle(anahtar);
        string yeni = "";
        foreach (char c in anahtar) if (!yeni.Contains(c)) yeni += c;
        foreach (char c in Alfabe30) if (!yeni.Contains(c)) yeni += c;
        return yeni;
    }
    // SifrelemeMotoru sınıfının içine ekle
    public static string VigenereSifrele(string metin, string anahtar)
    {
        string temizMetin = Temizle(metin);
        string temizAnahtar = Temizle(anahtar);

        if (string.IsNullOrEmpty(temizAnahtar)) return temizMetin;

        string sonuc = "";
        for (int i = 0; i < temizMetin.Length; i++)
        {
            int metinIndex = Alfabe.IndexOf(temizMetin[i]);
            // Anahtar kelimenin harfini mod alarak tekrar ettiriyoruz
            int anahtarIndex = Alfabe.IndexOf(temizAnahtar[i % temizAnahtar.Length]);

            // Formül: (Metin İndis + Anahtar İndis) % 29
            int yeniIndex = (metinIndex + anahtarIndex) % Alfabe.Length;
            sonuc += Alfabe[yeniIndex];
        }
        return sonuc;
    }

    public static string VigenereCoz(string sifreliMetin, string anahtar)
    {
        string temizAnahtar = Temizle(anahtar);
        if (string.IsNullOrEmpty(temizAnahtar)) return sifreliMetin;

        string sonuc = "";
        for (int i = 0; i < sifreliMetin.Length; i++)
        {
            int sifreIndex = Alfabe.IndexOf(sifreliMetin[i]);
            int anahtarIndex = Alfabe.IndexOf(temizAnahtar[i % temizAnahtar.Length]);

            // Formül: (Şifreli İndis - Anahtar İndis + 29) % 29
            int yeniIndex = (sifreIndex - anahtarIndex + Alfabe.Length) % Alfabe.Length;
            sonuc += Alfabe[yeniIndex];
        }
        return sonuc;
    }
}