# **Library Management System**

Bu proje, **Clean Architecture** prensiplerine göre geliştirilmiş bir **Library Management System** uygulamasıdır. Projede kullanıcı kimlik doğrulama, rol yönetimi, kitap yönetimi, Redis tabanlı cacheleme, pagination ve repository/unit-of-work pattern'leri uygulanmıştır.

---

## **Özellikler**

1. **Admin Kullanıcısı ve Rol Yönetimi**
   - Proje ilk kez başlatıldığında otomatik olarak **Admin rolü** ve **admin kullanıcısı** oluşturulur.
   - Admin, yeni kullanıcıların yetkilerini belirler ve yönetir.
   - **Admin Giriş Bilgileri**:
     - **Email**: `admin@gmail.com`  
     - **Password**: `admin123`  

2. **Cookie Bazlı Kimlik Doğrulama**
   - Kullanıcılar cookie tabanlı oturum açabilir.
   - Rol bazlı yetkilendirme ile **Admin** rolü tüm sayfalara erişebilir, kullanıcılar ise yetkilendirildikleri sayfalara erişebilir.

3. **Repository ve UnitOfWork Pattern**
   - **Book** işlemleri için Repository pattern uygulanmıştır.
   - Veritabanı işlemlerini **UnitOfWork** deseni yönetir.

4. **Redis Cache Kullanımı**
   - Redis, kitap listeleri gibi sık kullanılan verilerin cache'lenmesini sağlar.
   - Kitap ekleme, silme veya güncelleme durumunda ilgili cache otomatik temizlenir.

5. **Pagination (Sayfalama)**
   - Kitap listeleri sayfa numarası (`pageNumber`) ve sayfa boyutuna (`pageSize`) göre gösterilir.
   - **Pagination Extension** metodu ile gelen sorgular sayfalama yapısına dönüştürülür.

6. **Result Pattern ve ProblemDetails**
   - Servis katmanında **Result Pattern** kullanılarak sonuç yönetimi sağlanır.
   - Hata durumlarında **ProblemDetails** ile anlaşılır hata mesajları döner.

---

## **Kurulum Adımları**

### **1. Redis Kurulumu**

```bash
docker run --name redis -p 6379:6379 -d redis
```

## **Veritabanı Ayarları**

Proje, **SQL Server** kullanarak veritabanı yönetimini gerçekleştirir. Veritabanı ayarlarını `appsettings.json` dosyasına ekleyin:

```json
"ConnectionStrings": {
  "Database": "Server=(localdb)\\omer;Database=LibraryManagement;Trusted_Connection=True;"
},
"Redis": {
  "ConnectionString": "localhost:6379"
}
```

## **Migration ve Data Seed**
```bash
Update-Database
```

## **Kullanıcı Yönetimi**

### **Admin Kullanıcısı**

Proje ilk çalıştırıldığında aşağıdaki admin kullanıcısı otomatik olarak oluşturulur:

- **Email**: `admin@gmail.com`  
- **Password**: `admin123`  

Admin kullanıcısı:
- Tüm sayfalara erişim yetkisine sahiptir.
- Yeni kullanıcıları oluşturabilir ve onlara rol atayabilir.

---


### **Kullanıcı Kayıt Olma**

Yeni kullanıcılar sistemde **Sign Up** sayfası üzerinden kayıt olabilirler. Ancak kayıt olan kullanıcılar varsayılan olarak **herhangi bir role atanmaz** ve dolayısıyla sayfalara erişimleri sınırlıdır.

- Admin kullanıcı, kullanıcıları yetkilendirerek belirli roller atayabilir.  
- Roller atandıktan sonra kullanıcılar ilgili yetkilerle sayfalara erişebilir.
- Model üzerinde bazı validasyonlar bulunmaktadır.

![image](https://github.com/user-attachments/assets/c2e73faf-e67e-4bda-86a0-d3715cfcea58)


---

### **Rol Atama ve Yönetimi**

**Rol Yönetimi** işlemleri **Admin** yetkisine sahip kullanıcılar tarafından yapılabilir.

1. **Rol Atama**:
   - Admin, yeni kullanıcıları listeler.
   - İlgili kullanıcının seçenklerinden giderek rol atama işlemi yapılır.
  ![image](https://github.com/user-attachments/assets/1b72e9dd-1a1d-4b14-9858-34ba0b4fa1df)


2. **Rol Silme**:
   - Admin, kullanıcıların rollerini iptal edebilir.
     ![image](https://github.com/user-attachments/assets/ad832710-6018-41c8-a33c-cbdae96b1d25)


     ![image](https://github.com/user-attachments/assets/cb98c79c-6690-42af-9a3a-fb40f513cd06)


3. **Access Denied**:
   - Yetkisiz kullanıcılar bir sayfaya erişmeye çalıştığında `/Role/AccessDenied` sayfasına yönlendirilir.
  
     ![image](https://github.com/user-attachments/assets/7f02505e-3b74-4ba5-9be6-01aaccd43fc0)


**Örnek Senaryo**:
- Kullanıcı kayıt olur.
- Admin, kullanıcıya bir rol (örneğin: "User") atar.
- Kullanıcı, rolüne uygun olan sayfalara erişebilir.

---

### **Giriş ve Çıkış İşlemleri**

#### **Giriş (Sign In)**  
- Kullanıcılar sisteme kayıt olduktan sonra **Email** ve **Password** bilgileri ile giriş yapabilir.  
- Giriş sırasında cookie bazlı kimlik doğrulama kullanılır.  
- Yetkisi olmayan kullanıcılar, yetkilendirilmiş sayfalara erişemez ve "Access Denied" sayfasına yönlendirilir.
![image](https://github.com/user-attachments/assets/e22e31c7-a518-485f-84fa-403ecf7d4c54)

