using System;
using System.Collections.Generic;

namespace VeriYapilari 
{


public class Ogrenci
{
    public Ogrenci sag, sol;

    public string adi_soyad, cinsiyet, kullanici_adi, sifre, bolum;
    public int ogrenci_id, donem;

    public Ogrenci(string adi_soyad, string cinsiyet, int ogrenci_id, int donem, string kullanici_adi, string sifre, string bolum)
    {
        this.adi_soyad = adi_soyad;
        this.cinsiyet = cinsiyet;
        this.ogrenci_id = ogrenci_id;
        this.donem = donem;
        this.kullanici_adi = kullanici_adi;
        this.sifre = sifre;
        this.bolum = bolum;
        this.sag = null;
        this.sol = null;
    }

}


public class OgretimGorevlisi
{
    public OgretimGorevlisi sol, sag;
    public string adi_soyad, cinsiyet, kullanici_adi, sifre;
    public int ogretmen_id;

    public OgretimGorevlisi(string adi_soyad, string cinsiyet, string kullanici_adi, string sifre, int ogretmen_id)
    {
        this.adi_soyad = adi_soyad;
        this.cinsiyet = cinsiyet;
        this.kullanici_adi = kullanici_adi;
        this.sifre = sifre;
        this.ogretmen_id = ogretmen_id;
        this.sol = null;
        this.sag = null;
    }
}

public class Ders
{
    public Ders sonraki, onceki;
    public string ders_adi, gun_id, ders_turu;
    public int ogretmen_id, ders_kredi, ders_id, saat_id, donem_id;

    public Ders(string ders_adi, string gun_id, string ders_turu, int ogretmen_id, int ders_id, int saat_id, int donem_id, int ders_kredi)
    {
        this.ders_adi = ders_adi;
        this.gun_id = gun_id;
        this.ders_turu = ders_turu;
        this.ogretmen_id = ogretmen_id;
        this.ders_id = ders_id;
        this.saat_id = saat_id;
        this.donem_id = donem_id;
        this.ders_kredi = ders_kredi;
        this.sonraki = null;
        this.onceki = null;
    }
}

public class Liste
{
    public List<Ders> dersListe;
    public int maksKapasite;
    public int kapasite;

    public Liste(int makKapasite)
    {
        dersListe = new List<Ders>(maksKapasite);
        kapasite = 0;
    }

    public void elemanEkle(Ders yeniDers)
    {
        if (kapasite <= maksKapasite)
        {
            dersListe.Add(yeniDers);
            kapasite++;
        }
        else 
        {
            Console.WriteLine("Yer Yok...");
        }

    }

    public Ders elamanBul(int hedefId)
    {
        for (int i = 0; i < kapasite; i++)
        {
            if (dersListe[i].ders_id == hedefId)
            {
                return dersListe[i];
            }
        }
        return null;
    }

     public void ElamanYaz()
     {
         for (int i = 0; i < kapasite; i++)
         {
             Console.WriteLine(dersListe[i].ders_adi);
         }
     }


    }

public class HashTable
{
    public List<Liste> liste1;
    public int hkapasite;

    public HashTable(int hkapasite, int listekapasite)
    {
        this.hkapasite = hkapasite;
        liste1 = new List<Liste>(hkapasite);
        for (int i = 0; i < hkapasite; i++)
        {
            liste1.Add(new Liste(listekapasite));
            liste1[i].maksKapasite = listekapasite;
        }
    }

    
    public void Ekle(Ders yeniDers)
    {
        int deger = (yeniDers.donem_id/10)-1;
        int anahtar = ((yeniDers.donem_id % 10) + (deger*4)) % hkapasite;
        liste1[anahtar].elemanEkle(yeniDers);
    }

    public Ders HashBul(int donemi, int idsi)
    {
            int deger = (donemi / 10) - 1;
            int anahtar = ((donemi % 10) + (deger * 4)) % hkapasite;
            return liste1[anahtar].elamanBul(idsi);
    }

    public Liste ListBul(int donemi)
    {
            int deger = (donemi / 10) - 1;
            int anahtar = ((donemi % 10) + (deger * 4)) % hkapasite;
            return liste1[anahtar];
    }
}


public class IkiYonluBagliListe
{
    public Ders baslangic;
    public int kapasite;

    public IkiYonluBagliListe()
    {
        this.baslangic = null;
        this.kapasite = 0;
    }

    public void Ekle(Ders yeniDugum)
    {
        kapasite++;

        if (baslangic == null)
        {
            baslangic = yeniDugum;
        }

        else
        {
            Ders guncel = baslangic;
            while (guncel.sonraki != null)
            {
                guncel = guncel.sonraki;
            }

            guncel.sonraki = yeniDugum;
            yeniDugum.onceki = guncel;
        }
    }

    public void Sil(int ders_id)
    {
        Ders silinecekDugum = ElemanBul(ders_id);

        if (silinecekDugum == null)
        {
            return;
        }

        if (silinecekDugum.onceki == null)
        {
            baslangic = silinecekDugum.sonraki;
        }
        else
        {
            silinecekDugum.onceki.sonraki = silinecekDugum.sonraki;
        }

        if (silinecekDugum.sonraki != null)
        {
            silinecekDugum.sonraki.onceki = silinecekDugum.onceki;
        }
    }

    public Ders ElemanBul(int arananDeger)
    {
        Ders gecici = baslangic;
        while (gecici != null)
        {
            if (gecici.ders_id == arananDeger)
            {
                return gecici;
            }
            gecici = gecici.sonraki;
        }
        return null;
    }

    public void Dugumders_idGoster()
    {
        Ders gecici = baslangic;
        while (gecici != null)
        {
            Console.Write(gecici.ders_id + " -> ");
            gecici = gecici.sonraki;
        }
        Console.WriteLine();
    }


    public bool GunVeSaatCakisiyorMu(string gun_id, int saat_id)
    {
        Ders gecici = baslangic;
        while (gecici != null)
        {
            if (gecici.gun_id == gun_id && gecici.saat_id == saat_id)
            {
                return true;
            }
            gecici = gecici.sonraki;
        }
        return false;
    }

    public int ToplamKredi()
    {
        int toplamKredi = 0;
        Ders gecici = baslangic;
        while (gecici != null)
        {
            toplamKredi += gecici.ders_kredi;
            gecici = gecici.sonraki;
        }
        return toplamKredi;
    }


    }

public class NodeOgr
{
    public Ogrenci Ogrenci { get; set; }
    public int Height { get; set; }
    public NodeOgr Left { get; set; }
    public NodeOgr Right { get; set; }

    public NodeOgr(Ogrenci ogrenci)
    {
        Ogrenci = ogrenci;
        Height = 1;
    }
}

public class NodeGorevli
{
    public OgretimGorevlisi OgretimGorevlisi { get; set; }
    public int Height { get; set; }
    public NodeGorevli Left { get; set; }
    public NodeGorevli Right { get; set; }

    public NodeGorevli(OgretimGorevlisi ogretimGorevlisi)
    {
        OgretimGorevlisi = ogretimGorevlisi;
        Height = 1;
    }
}
public class OgrenciAVL
{
    private NodeOgr root;

    public void InsertOgr(Ogrenci ogrenci)
    {
        root = InsertNode(root, ogrenci);
    }

    private NodeOgr InsertNode(NodeOgr node, Ogrenci ogrenci)
    {
        if (node == null)
            return new NodeOgr(ogrenci);

        if (ogrenci.ogrenci_id < node.Ogrenci.ogrenci_id)
            node.Left = InsertNode(node.Left, ogrenci);
        else if (ogrenci.ogrenci_id > node.Ogrenci.ogrenci_id)
            node.Right = InsertNode(node.Right, ogrenci);
        else
            return node;

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        int balanceFactor = GetBalanceFactor(node);

        if (balanceFactor > 1)
        {
            if (ogrenci.ogrenci_id < node.Left.Ogrenci.ogrenci_id)
                return RotateRight(node);

            if (ogrenci.ogrenci_id > node.Left.Ogrenci.ogrenci_id)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
        }

        if (balanceFactor < -1)
        {
            if (ogrenci.ogrenci_id > node.Right.Ogrenci.ogrenci_id)
                return RotateLeft(node);

            if (ogrenci.ogrenci_id < node.Right.Ogrenci.ogrenci_id)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
        }

        return node;
    }

    private int GetHeight(NodeOgr node)
    {
        if (node == null)
            return 0;

        return node.Height;
    }

    private int GetBalanceFactor(NodeOgr node)
    {
        if (node == null)
            return 0;

        return GetHeight(node.Left) - GetHeight(node.Right);
    }

    private NodeOgr RotateRight(NodeOgr y)
    {
        NodeOgr x = y.Left;
        NodeOgr T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));
        x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));

        return x;
    }

    private NodeOgr RotateLeft(NodeOgr x)
    {
        NodeOgr y = x.Right;
        NodeOgr T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));
        y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));

        return y;
    }

    public NodeOgr SearchTree(string kullanici)
        {
        if (root != null)
        {
            return PrintInOrder(root,kullanici);
        }
        return null;
    }

    private NodeOgr PrintInOrder(NodeOgr node, string kullanici)
    {
        if (node != null)
        {
            if (node.Ogrenci.kullanici_adi == kullanici)
                return node;
            NodeOgr x = PrintInOrder(node.Left, kullanici);
            if (x == null)
                x = PrintInOrder(node.Right, kullanici);
            return x;
        }
        return null;
        }
    public NodeOgr FindOgrenciID(int ogrenciID)
    {
        NodeOgr foundNode = FindOgrenci(root, ogrenciID);
        if (foundNode != null)
            return foundNode;
        else
            return null;
    }

    private NodeOgr FindOgrenci(NodeOgr node, int ogrenciID)
    {
        if (node == null || node.Ogrenci.ogrenci_id == ogrenciID)
            return node;

        if (ogrenciID < node.Ogrenci.ogrenci_id)
            return FindOgrenci(node.Left, ogrenciID);
        else
            return FindOgrenci(node.Right, ogrenciID);
    }
}


public class OgretimGorevlisiAVL
{
    private NodeGorevli root;

    public void InsertGorevli(OgretimGorevlisi ogretimGorevlisi)
    {
        root = InsertNode2(root, ogretimGorevlisi);
    }
    private NodeGorevli InsertNode2(NodeGorevli node, OgretimGorevlisi ogretimGorevlisi)
    {
        if (node == null)
            return new NodeGorevli(ogretimGorevlisi);

        if (ogretimGorevlisi.ogretmen_id < node.OgretimGorevlisi.ogretmen_id)
            node.Left = InsertNode2(node.Left, ogretimGorevlisi);
        else if (ogretimGorevlisi.ogretmen_id > node.OgretimGorevlisi.ogretmen_id)
            node.Right = InsertNode2(node.Right, ogretimGorevlisi);
        else
            return node;

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        int balanceFactor = GetBalanceFactor(node);

        if (balanceFactor > 1)
        {
            if (ogretimGorevlisi.ogretmen_id < node.Left.OgretimGorevlisi.ogretmen_id)
                return RotateRight(node);

            if (ogretimGorevlisi.ogretmen_id > node.Left.OgretimGorevlisi.ogretmen_id)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
        }

        if (balanceFactor < -1)
        {
            if (ogretimGorevlisi.ogretmen_id > node.Right.OgretimGorevlisi.ogretmen_id)
                return RotateLeft(node);

            if (ogretimGorevlisi.ogretmen_id < node.Right.OgretimGorevlisi.ogretmen_id)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
        }

        return node;
    }
    private int GetHeight(NodeGorevli node)
    {
        if (node == null)
            return 0;

        return node.Height;
    }

    private int GetBalanceFactor(NodeGorevli node)
    {
        if (node == null)
            return 0;

        return GetHeight(node.Left) - GetHeight(node.Right);
    }
    private NodeGorevli RotateRight(NodeGorevli y)
    {
        NodeGorevli x = y.Left;
        NodeGorevli T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));
        x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));

        return x;
    }

    private NodeGorevli RotateLeft(NodeGorevli x)
    {
        NodeGorevli y = x.Right;
        NodeGorevli T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));
        y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));

        return y;
    }
    public NodeGorevli SearchTree(string kullanici)
    {
        if (root != null)
        {
            return PrintInOrder(root, kullanici);
        }
        return null;
    }

    private NodeGorevli PrintInOrder(NodeGorevli node, string kullanici)
    {
        if (node != null)
        {
            if(node.OgretimGorevlisi.kullanici_adi == kullanici)
                    return node;
            NodeGorevli x = PrintInOrder(node.Left, kullanici);
            if (x == null)
                x = PrintInOrder(node.Right, kullanici);
            return x;
        }
        return null;
    }
    public NodeGorevli FindGorevliID(int ogretmen_id)
    {
        NodeGorevli foundNode = FindGorevli(root, ogretmen_id);
        if (foundNode != null)
            return foundNode;
        else
            return null;
    }

    private NodeGorevli FindGorevli(NodeGorevli node, int ogretmen_id)
    {
        if (node == null || node.OgretimGorevlisi.ogretmen_id == ogretmen_id)
            return node;

        if (ogretmen_id < node.OgretimGorevlisi.ogretmen_id)
            return FindGorevli(node.Left, ogretmen_id);
        else
            return FindGorevli(node.Right, ogretmen_id);
        }
    }
}

