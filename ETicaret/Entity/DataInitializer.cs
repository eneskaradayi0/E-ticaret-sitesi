using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ETicaret.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){ Name = "teknolojik aksesuar", Description = "teknolojik aksesuarlar"},
                new Category(){ Name = "Bilgisayar", Description = "Bilgisayar ürünleri"},
                new Category(){ Name = "Televizyon", Description = "Televizyon ürünleri"},
                new Category(){ Name = "Telefon", Description = "Telefon ürünleri"},
                new Category(){ Name = "donanım", Description = "Donanım ürünleri"}
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){ Name = "Apple iPhone 14 Pro Max 128 GB Derin Mor",Description = "Sihirli bir iPhone deneyimi. Hayat kurtarmak için tasarlanan bir güvenlik özelliği. İnovatif 48 MP Ana kamera. Ve gün ışığında 2 kata kadar daha parlak bir ekran.◊Yasal açıklama dipnotuna bakın Hepsi gücünü olağanüstü bir akıllı telefon.", Price =63.898,Stock =500 , IsApproved =true , CategoryId = 4,IsHome = true,Image = "1.jpg"},
                new Product(){ Name = "Xiaomi Redmi Watch 3 Active Akıllı Saat",Description = "Xiaomi Redmi Watch 3 Active, şık tasarımı ve özellikleriyle dikkat çeken bir akıllı saat modelidir", Price =1599 , Stock =500 , IsApproved =true , CategoryId = 1,IsHome = true,Image = "2.jpg"},
                new Product(){ Name = "Xnews AirPods Max - Gümüş Rengi",Description = "Xnews AirPods Max, mükemmel ses kalitesi ve zarif tasarımıyla sizi büyüleyecek. Gümüş rengi seçeneği, şıklığınıza ve tarzınıza mükemmel bir uyum sağlar. Bu premium kablosuz kulaklık, üstün ses deneyimi ve konforlu bir kullanım sunar.", Price =45.207, Stock =500 , IsApproved =false , CategoryId = 1,IsHome = true,Image = "3.jpg"},
                new Product(){ Name = "MSI TITAN GT77 12UHS-037TR I9-12900HX 128GB DDR5 RTX3080TI GDDR6 16GB 2TB SSD 17.3 UHD 120Hz W11",Description = "Yüksek performansın sınırlarını zorlayan MSI TITAN GT77 12UHS-037TR dizüstü bilgisayar, güçlü donanım ve çarpıcı özellikleriyle oyun ve iş dünyası için tasarlanmış bir canavar. En son teknolojiyi sunan bu cihaz, size sınırsız bir deneyim vaat ediyor.", Price =245.999, Stock =500 , IsApproved =true , CategoryId = 2,IsHome = true,Image = "4.jpg"},
                new Product(){ Name = "CASPER Via X30 Plus 256GB Akıllı Telefon Platin Antrasit",Description = "CASPER Via X30 Plus, yüksek kapasiteli depolama, güçlü performans ve zarif tasarımı bir araya getiren bir akıllı telefondur. Gelişmiş özellikler ve şık görünümü ile bu telefon, günlük ihtiyaçlarınızı karşılamak ve stilinizi ifade etmek için mükemmel bir seçenektir.", Price =9999, Stock =500 , IsApproved =false , CategoryId = 4,Image = "5.jpg"},

                new Product(){ Name = "LENOVO Tab M8 (4th Gen) 3gb 32gb 8 Hd Tablet",Description="LENOVO Tab M8 (4. Nesil), ince tasarımı ve gelişmiş özellikleri ile sizlere mobil cihazlarda benzersiz bir deneyim sunuyor. Bu tablet, hem iş hem de eğlence için ideal bir seçenek sunar ve taşınabilirliği ile dikkat çeker.", Price =2.899, Stock =500 , IsApproved =true , CategoryId = 1 ,Image = "6.jpg"},
                new Product(){ Name = "Philips 43PUS8007 43 109 Ekran Uydu Alıcılı 4K Ultra HD Android Smart LED TV TV-PUS8007",Description = "Philips 43PUS8007, yüksek kaliteli görüntüler, akıllı işlevler ve modern tasarımı bir araya getiren mükemmel bir televizyondur. 4K Ultra HD çözünürlük, Android işletim sistemi ve uydu alıcısı ile size son derece zengin bir eğlence deneyimi sunar.", Price =10.699, Stock =1200 , IsApproved =true , CategoryId = 3,IsHome = true,Image = "7.jpg"},
                new Product(){ Name = "Corsair Corsaır Ch-910d018-tr K60 Pro Rgb Cherry Mx Low Profıle Turkce Mekanık Oyuncu Klavyesı",Description = "Corsair K60 Pro RGB, oyun dünyasında üstün performans ve stil arayan oyuncular için özel olarak tasarlanmıştır. Cherry MX Low Profile anahtarları, hızlı tepki süreleri ve düşük profil tasarımı ile mükemmel bir oyun deneyimi sunar.", Price =8.622 , Stock =0 , IsApproved =false , CategoryId = 5,IsHome = true,Image = "8.jpg"},
                new Product(){ Name = "logitech G402 Gaming Mouse USB Siyah 910-004068 G402-910-004068",Description = "Logitech G402, oyun dünyasında rekabetçi bir avantaj sağlayan yüksek performanslı bir oyun faresidir. Üstün hız, hassasiyet ve dayanıklılık sunan bu fare, her türlü oyun türüne uyum sağlar.", Price =969, Stock =600 , IsApproved =true , CategoryId = 5,Image = "9.jpg"},
                new Product(){ Name = "Xiaomi 33 Watt Fast Qualcomm Turbo Hızlı %100 Orjinal Mi Şarj Aleti Xiaomi 33W Şarj",Description = "Xiaomi, teknoloji dünyasında yenilikçi ve güvenilir ürünleriyle tanınır ve bu 33 Watt hızlı şarj cihazı da istisna değil. %100 orijinal Mi markası altında sunulan bu şarj cihazı, hızlı şarj özelliği ile akıllı telefonunuzu veya diğer cihazlarınızı daha hızlı ve güvenli bir şekilde şarj etmenizi sağlar.", Price =339, Stock =500 , IsApproved =true , CategoryId = 5,Image = "10.jpg"},

                new Product(){ Name = "Xiaomi Mi Band 7 Akıllı Bileklik - Siyah (Xiaomi Türkiye Garantili) Mi band 7", Description="Xiaomi Mi Band serisi, akıllı bilekliklerin öncüsü olarak tanınır ve Xiaomi Mi Band 7, şık tasarımı, özellik zenginliği ve uygun fiyatıyla bu geleneği sürdürüyor. Sağlığınızı ve günlük aktivitelerinizi izlemek için mükemmel bir yardımcıdır." ,Price =1071 , Stock =500 , IsApproved =true , CategoryId = 1,Image = "11.jpg"},
                new Product(){ Name = "Rampage Ad-rc34 Metafor Siyah Rgb 6 Fanlı Telefon Tutuculu Rgb Işıklı 10-19inç Notebook Soğutucu Stand AD-RC34",Description = " Rampage AD-RC34, yüksek performanslı bir notebook soğutucu standın ötesine geçiyor. Mükemmel soğutma, üstün taşınabilirlik ve şaşırtıcı RGB aydınlatma ile donatılmış, bu ürün, oyun deneyiminizi bir üst seviyeye taşıyor.", Price =899 , Stock =1200 , IsApproved =true , CategoryId = 5,Image = "12.jpg"},
                new Product(){ Name = "147 Ekran Uydu Alıcılı 4K Ultra HD Android Smart LED TV",Description = "Philips 58PUS8507, üstün görüntü kalitesi ve akıllı TV özelliklerini bir araya getiren büyüleyici bir televizyondur. Büyük ekranı, yüksek çözünürlüklü 4K Ultra HD görüntüleri ve zengin renkleri ile her görsel içeriği bir şölene dönüştürür.", Price =21.283 , Stock =0 , IsApproved =false , CategoryId =3,IsHome = true,Image = "13.jpg"},
                new Product(){ Name = "XIAOMI Poco X3 Pro",Description = "Xiaomi Poco X3 Pro, yüksek performans, büyük ekran ve uzun pil ömrü ile öne çıkan bir akıllı telefondur. Akıllı telefonunuzdan beklediğiniz tüm özellikleri sunarken, uygun bir fiyatla geliyor.", Price =45.997 , Stock =600 , IsApproved =true , CategoryId = 4,IsHome = true,Image = "14.jpg"},
                new Product(){ Name = "Sandisk SSD Plus 240GB 530MB-440MB/s Sata 3 2.5 SSD (SDSSDA-240G-G26)",Description = "SanDisk SSD Plus, bilgisayarınızın performansını anında artıran güvenilir ve hızlı bir depolama çözümüdür. Yüksek kapasite, hızlı veri aktarımı ve dayanıklı tasarımı ile bu SSD, bilgisayar deneyiminizi güncellemenize yardımcı olur", Price =399 , Stock =500 , IsApproved =true , CategoryId = 5,Image = "15.jpg"},

                new Product(){ Name = "Zotac Gaming GeForce RTX 3060 Twin Edge 12 GB GDDR6 192 Bit DP/HDMI Pci-E 4.0 Ekran Kartı ZT-A30600E-10M", Description="Zotac Gaming GeForce RTX 3060 Twin Edge, en yeni oyunlar ve görsel uygulamalar için yüksek performanslı bir ekran kartıdır. Güçlü RTX serisi grafikleri, zengin ayrıntılar, canlı renkler ve akıcı oyun deneyimi sunar." ,Price =8.499 , Stock =500 , IsApproved =true , CategoryId = 5,Image = "16.jpg"},
                new Product(){ Name = "ASUS TUF GAMING VG248Q1B 24 165hz 0.5ms (DP+HDMI+MM) FreeSync 1920x1080 LED Gaming Monitör",Description = "ASUS TUF GAMING VG248Q1B, oyuncular için tasarlanmış yüksek performanslı bir oyun monitörüdür. 165Hz tazeleme hızı, 0.5ms tepki süresi ve AMD FreeSync teknolojisi ile donatılmış, akıcı ve kesintisiz oyun deneyimi sunar.", Price =4.198 , Stock =1200 , IsApproved =true , CategoryId = 5,IsHome = true,Image = "17.jpg"},
                new Product(){ Name = "Samsung Galaxy A54 128 GB 8 GB Ram (Samsung Türkiye Garantili)",Description = "Samsung Galaxy A54, şıklığı ve performansı bir araya getiren, güçlü özelliklere sahip bir akıllı telefondur. Samsung'un güvencesiyle sunulan bu cihaz, kullanıcılarına zengin bir deneyim sunar.", Price =14.499 , Stock =0 , IsApproved =false , CategoryId =4,IsHome = true,Image = "18.jpg"},
                new Product(){ Name = "Aprilia ESR1 Elektirikli Scooter",Description = "Aprilia, motorsiklet dünyasında kalite ve performansla tanınırken, şimdi geleceğin taşımacılığına yepyeni bir boyut kazandırıyor. Aprilia ESR1, elektrikli scooter dünyasında üstün performansı ve şık tasarımı bir araya getirirken, çevre dostu bir sürüş deneyimi sunuyor.", Price =20.879 , Stock =600 , IsApproved =true , CategoryId = 5,Image = "19.jpg"},
                new Product(){ Name = "Hp Omen 45L GT22-0014NT Amd Ryzen 7 5800X 8gb Rtx 3070 32GB 3733MHZ Rgb Ram 2tb M2 SSD Windows 11 Home Masaüstü Bilgisayar 6M457EA",Description = "HP Omen 45L GT22-0014NT, oyun deneyiminizi bir üst seviyeye taşımak için tasarlanmış yüksek performanslı bir masaüstü bilgisayardır. Son teknoloji bileşenlerle donatılmış bu canavar, oyunları en yüksek ayarlarda oynamanıza ve yaratıcılığınızı sınırlarını zorlamanıza olanak tanır.", Price =58.299 , Stock =500 , IsApproved =true , CategoryId = 2,Image = "20.jpg"},

            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}