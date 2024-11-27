
# Online Ticari Otomasyon

Bu proje geliştirilirken Evkur vb. bir mağazanın yaptıkları satışları, personel hareketlerini, ürün giriş/çıkışlarını, kargo takip süreçlerini, fatura işlemlerini ve grafikler aracılığıyla istatistikleri görebilecekleri bir sistem ortaya çıkartmak hedeflenmiştir. Sistem 2 ana panel üzerine kurulmuştur: Cari Paneli ve Personel Paneli.
## Cari Paneli

Müşteriler mağazadan alışveriş yaptıklarında kendilerine verilen kullanıcı adı ve şifre bilgileriyle cari paneline girebiliyorlar. Bu panel aracılığıyla aşağıdaki işlemleri gerçekleştirebiliyorlar:

- Müşteri profil sayfasında kişisel bilgilerini güncelleyebiliyor.
- Şimdiye kadar gerçekleştirdiği toplam satış, aldığı ürün ve harcadığı para miktarını görüntüleyebiliyor.
- Mağazanın müşterilere özel yaptığı duyurulara erişebiliyor.
- Sipariş detaylarını görüntüleyebiliyor.
- Kargoda olan ürünlerinin takibini gerçekleştirebiliyor.
- Sistemdeki diğer kullanıcılarla mesajlaşabiliyor.
## Personel Paneli

Mağazanın her kademesinde çalışan personellere verilen kişisel giriş bilgileri aracılığıyla erişebildikleri bu panel üzerinde "yetkileri" dahilinde her personel "kendisine tanımlanan yetki/rol kapsamında" çeşitli işlemler gerçekleştirebiliyorlar. Bu işlemlerden bazıları ise şöyle:

- Dashboardda çeşitli istatistiksel verileri görüntüleyerek anlık olarak sisteme hızlı bakış atabiliyorlar.
- Kategori işlemleri sayfasında, kategori ekleme/silme/güncelleme/listeleme işlemlerini gerçekleştirebiliyorlar.
- Ürün işlemleri sayfasında ise ürün ekleme/silme/güncelleme/listeleme işlemlerine ek olarak ürün satışı gerçekleştirme veya Excel/PDF çıktısı alma işlemlerini yapabiliyorlar.
- Departman işlemleri sayfasında, departman ekleme/silme/güncelleme/listeleme işlemlerine ek olarak ilgili departmanlardaki çalışan personel bilgilerine ve hatta o personellerin hangi satışları gerçekleştirdiği bilgilerine ulaşabiliyorlar.
- Cari işlemleri sayfasında, cari ekleme/silme/güncelleme/listeleme işlemlerine ek olarak ilgili carinin satış geçmişini görüntüleyebiliyorlar.
- Personel işlemleri sayfasında, sistemdeki personellerin bilgilerini görüntüleme/güncelleme işlemlerinin yanısıra personellerin yaptıkları satışları da görebilmektedirler.
- Satışlar sayfasında ise satışları görüntüleme/güncelleme işlemlerine ek olarak yeni satış yapma işlemlerini de gerçekleştirebilmektedirler.
- Faturalar sayfasında ise sisteme dinamik bir şekilde yeni fatura ve fatura kalemleri ekleme işlemleri yapılabilmektedir.
- Grafikler sayfasında ise 3 farklı çeşitte (Pie, Line, Column) grafik ile istatistiksel veriler görüntülenmektedir.
- Kargolar sayfasında ise sistemdeki kargoların detaylarını görebilmekte ve kargolarını takip edebilmeleri için carilere iletilmesi için "karekod oluşturabilmektedirler".
- Galeri sayfasında ise sistemdeki ürünlere ait görselleri görüntüleyebiliyorlar.
## Proje Özellikleri

- Projede 20'ye yakın tablo kullanıldı ve veritabanı olarak MSSQL tercih edildi.
- Entity Framework ile Code First yaklaşımıyla geliştirildi.
- Çeşitli scriptler (dinamik fatura ve fatura kalemleri oluşturma scriptleri, adedi ve fiyatı girilen ürünlerin toplam tutarının otomatik hesaplanmasını sağlayan scriptler) kullanıldı.
- Harici kütüphanelerin eklenmesiyle Karekod oluşturma işlemleri yapıldı.
- Oturum yönetimi Session ile gerçekleştirildi. Güvenlik için Authorize ve Authentication'lar kullanıldı.
- Google Charts ve Sweet Alert kullanıldı.
- Projemize özel hata sayfaları (403, 404, 500) oluşturuldu.

  
## Kullanılan Teknolojiler

- Code First / EntityFramework
- Authentication / Authorize / Validation
- MSSQL
- İlişkisel Tablolar Üzerinde LINQ Sorguları
- Partial Views
- Modal Popup / Sweet Alert / Google Chart
- DataTable / Pagination / Searching
- QR Kod Oluşturma
- Trigger ve Prosedür
- Custom Error Pages
## Ekran Görüntüleri

![login](https://github.com/user-attachments/assets/29065c75-c9a3-4f78-a592-af7a9c9d8ada)
![cari_giris](https://github.com/user-attachments/assets/9c6f2e7c-72d9-43e7-bcc0-34ce87b04813)
![cari_kayit](https://github.com/user-attachments/assets/c46ae61a-a781-442f-83e1-415b463afe8a)
![personel_giris](https://github.com/user-attachments/assets/f3719eee-c30a-48e3-8eaf-7ae181f41888)
![cari_profil](https://github.com/user-attachments/assets/2c145e5f-4454-43fb-abf2-ec5d185e6aae)
![cari_siparislerim](https://github.com/user-attachments/assets/d2fbf11c-4d14-4713-a9b0-f242003850b5)
![cari_kargotakip_1](https://github.com/user-attachments/assets/d11deb76-319f-4297-b25e-7c5070715ccc)
![cari_kargotakip_2](https://github.com/user-attachments/assets/389a6797-976d-4849-bffa-dd60f47eb6f0)
![cari_kargotakip_3](https://github.com/user-attachments/assets/775974bd-2abf-408c-bba2-6fc3e88549a5)
![cari_mesajlar](https://github.com/user-attachments/assets/89c3db95-dee9-482a-9df9-b1341b9465bd)
![personel_dashboard](https://github.com/user-attachments/assets/44bc33b6-4073-4f3f-b136-5551e241df63)
![personel_urunlistesi](https://github.com/user-attachments/assets/feca1b8c-b6f2-45eb-9d92-7d61727474a6)
![personel_urunguncelle](https://github.com/user-attachments/assets/fea24cc5-b8f7-418a-ac02-907b8a52bf96)
![personel_departmandetay](https://github.com/user-attachments/assets/b9306a1e-8a10-44db-b0df-98259e9ad0f5)
![personel_departmanpersonelsatis](https://github.com/user-attachments/assets/e66cd614-003e-4098-882f-9df7b14d9feb)
![personel_personellistesi](https://github.com/user-attachments/assets/594e2986-dfce-4603-aa0b-e77b26148c69)
![personel_faturalar](https://github.com/user-attachments/assets/eb511531-08cf-4961-a4b1-f59a1de7d1b2)
![personel_piechart](https://github.com/user-attachments/assets/70a1f112-4ff0-4ecf-a9f0-fd917d9b7808)
![personel_QR1](https://github.com/user-attachments/assets/2c9a1770-d65c-4e80-858a-851e56de6270)
![personel_QR2](https://github.com/user-attachments/assets/f6e6460c-94c9-4fd1-88e5-b739514a9cd8)
![personel_galeri](https://github.com/user-attachments/assets/b8da0eb8-ae0e-4dab-b9be-2834344aa921)
![personel_yenifaturagirisi](https://github.com/user-attachments/assets/7521707f-3a28-4af0-9f21-2c76b7c19e37)


  
