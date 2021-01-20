using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CustomerTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>()
            {
                //new Customer("21427586892", "Ege DENİZ", DateTime.Now),
                //new Customer("21486744868", "Ali Veli", new DateTime(2005, 5, 1, 10, 28, 52)),
                //new Customer("48484684848", "Murat Kaya", new DateTime(2001, 11, 14, 8, 30, 52))
            };

            CustomerManager customerManager = new CustomerManager(customers);

            Console.WriteLine("---------------- Welcome To MAZE BANK -----------------------");

            Console.WriteLine("\"Invest in the red, it's in your interest\"");

            string islemMetni = "Maze Bank müşteri işlemleri :\n" +
                                "1 - Müşteri Ekle\n" +
                                "2 - Müşteri Sil\n" +
                                "3 - Müşteri Güncelle (Ad Soyad)\n" +
                                "4 - Müşteri Bilgileri\n" +
                                "5 - Tüm Müşteriler\n" +
                                "Menüyü tekrar görebilmek için m'ye basınız.\n" +
                                "Çıkış için q'ya basınız.\n" +
                                "*Seçmek istediğiniz işlemin yanındaki numarayı tuşlayınız.";

            bool cikis = false;

            Console.WriteLine(islemMetni);

            while (!cikis)
            {
                Console.WriteLine("--------------------------------------");

                Console.Write("İşlem seçiniz : ");

                string islemTuru = Console.ReadLine();

                if (islemTuru.Equals("q"))
                {
                    Console.WriteLine("Çıkış Yapılıyor...  -Maze Bank Of Los Santos");
                    Thread.Sleep(1000);
                    cikis = true;
                    Console.WriteLine("Programdan çıkıldı. Ekranı kapatmak için bir tuşa basınız.");
                }
                else if (islemTuru.Equals("m"))
                {
                    Console.WriteLine(islemMetni);
                }
                else if (islemTuru.Equals("1"))
                {
                    Console.WriteLine("---------- Müşteri Kayıt --------------");

                    Console.Write("Ad Soyad : ");
                    string name = Console.ReadLine();             

                    Console.Write("TC Kimlik Numarası : ");
                    string identity = Console.ReadLine();

                    Beklet();

                    var add = customerManager.Add(new Customer(identity, name, DateTime.Now));
                    if(add != null)
                    {
                        Console.WriteLine("{0} adlı müşteri sisteme kaydedildi. Müşteri TC : {1}", add.Name, add.Identity);
                    }
                    else
                    {
                        Console.WriteLine("Bu müşteri zaten sistemde kayıtlı. Müşteri TC : {0}", identity);
                    }
                    
                }
                else if (islemTuru.Equals("2"))
                {
                    Console.WriteLine("---------- Müşteri Sil --------------");

                    Console.Write("Silinecek müşterinin TC Kimlik Numarası : ");
                    string identity = Console.ReadLine();

                    Beklet();

                    var remove = customerManager.Remove(identity);
                    if (remove)
                    {
                        Console.WriteLine("{0} TC Kimlik numaralı müşteri silindi.", identity);
                    }
                    else
                    {
                        Console.WriteLine("Hatalı TC! Sistemde böyle bir kayıt bulunmuyor.");
                    }


                }
                else if (islemTuru.Equals("3"))
                {
                    Console.WriteLine("---------- Müşteri Güncelle --------------");

                    Console.Write("Güncellenecek müşterinin TC Kimlik Numarası : ");
                    string identity = Console.ReadLine();

                    Console.Write("Yeni Ad Soyad : ");
                    string name = Console.ReadLine();

                    Beklet();

                    var update = customerManager.Update(identity, name);
                    if (update != null)
                    {
                        Console.WriteLine("{0} TC Kimlik numaralı müşterinin adı {1} olarak güncellendi.", update.Identity, update.Name);
                    }
                    else
                    {
                        Console.WriteLine("Hatalı TC! Sistemde böyle bir kayıt bulunmuyor.");
                    }
                }
                else if (islemTuru.Equals("4"))
                {
                    Console.WriteLine("---------- Müşteri Bilgileri --------------");

                    Console.Write("TC Kimlik Numarası : ");
                    string identity = Console.ReadLine();

                    Beklet();

                    var musteriDetay = customerManager.GetRow(identity);
                    if (musteriDetay != null)
                    {
                        Console.WriteLine(" Müşteri Bilgileri -> ID : {0}, TC : {1}, Ad Soyad : {2}, Kayıt Tarihi : {3}", musteriDetay.ID, musteriDetay.Identity, musteriDetay.Name, musteriDetay.DateOfRegistration);
                    }
                    else
                    {
                        Console.WriteLine("Hatalı TC! Sistemde böyle bir kayıt bulunmuyor.");
                    }
                }
                else if (islemTuru.Equals("5"))
                {
                    Console.WriteLine("---------- Tüm Müşteri Bilgileri --------------");

                    customerManager.GetAllList();
                }
                else
                {
                    Console.WriteLine("Geçersiz İşlem! Lütfen tekrar giriniz.");
                }
            }

            void Beklet()
            {
                Console.WriteLine("İşlem yapılıyor lütfen bekleyiniz...");
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }
    }
}
