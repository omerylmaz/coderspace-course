# Online Eğitim Platformu - Backend ve Frontend Entegrasyonu

Bu proje, online eğitim platformu için backend ve frontend entegrasyonunu sağlayan bir uygulamadır. Projede kullanıcı yönetimi, kurs yönetimi, ödeme işlemleri ve bildirim sistemleri gibi çeşitli özellikler bulunmaktadır.

---

## 📜 **Projenin Genel Akışı ve Entity Relationship Diagramı (ERD)**

![ERD Diagram](https://prod-files-secure.s3.us-west-2.amazonaws.com/a739d642-54d0-47ae-9406-03c1eecb017b/66587127-9aff-4a19-bd7b-ac6283534f17/image.png)

---

## 📂 **Entity Tanımları**

### 1. **AppUser**
- **Amaç**: Sistemdeki kullanıcıları temsil eder.
- **İlişkiler**:
  - **Notification**: Kullanıcının bildirimlerini saklar.
  - **Order**: Kullanıcının satın aldığı kursları yönetir.
  - **UserRefreshToken**: Oturum yenileme işlemleri için kullanılır.
  - **AppRole**: Kullanıcının rol ve yetkilerini tanımlar.

### 2. **AppRole**
- **Amaç**: Kullanıcıların rol ve yetkilerini tanımlar.
- **İlişkiler**: Kullanıcı ile rolleri **AspNetUserRoles** üzerinden ilişkilendirilmiştir.

### 3. **Category**
- **Amaç**: Kursları kategorize eder (örn: Yazılım, Tasarım).
- **İlişkiler**: Bir kategoride birden fazla kurs bulunabilir.

### 4. **Course**
- **Amaç**: Satılan kursların bilgilerini içerir.
- **İlişkiler**:
  - Bir **Category** ve bir **Teacher** ile ilişkilidir.
  - Birden fazla **Content** barındırır.
  - Satış işlemleri **Order** ile ilişkilendirilmiştir.

### 5. **Content**
- **Amaç**: Kurs altındaki ders içeriklerini temsil eder.
- **İlişkiler**: Her içerik bir **Course** ile ilişkilidir.

### 6. **Notification**
- **Amaç**: Kullanıcı bildirimlerini saklar.
- **Senaryo**: Yeni kurs eklendiğinde kullanıcıya bildirim gönderilir.

### 7. **Order**
- **Amaç**: Kurs satın alma işlemlerini yönetir.
- **İlişkiler**:
  - **AppUser** ve **Course** ile ilişkilidir.
  - Ödeme bilgisi **Payment** ile ilişkilidir.

### 8. **Payment**
- **Amaç**: Ödeme işlemlerini takip eder.
- **İlişkiler**: Bir **Order** ile ilişkilidir.

### 9. **UserRefreshToken**
- **Amaç**: Kullanıcının oturum yenileme tokenlarını saklar.
- **İlişkiler**: Her token bir **AppUser** ile ilişkilidir.

---

## ⚙️ **Kullanılan Teknolojiler**

### **Backend**
- Mediatr
- Redis
- RabbitMQ
- İyziPay
- FluentValidation
- AutoMapper
- JWTBearer
- Entity Framework
- SqlServerIdentity
- Masstransit

### **Frontend**
- **Ana Bağımlılıklar**:
  - React
  - Axios
  - React-Router-Dom
  - React-Hook-Form
  - Yup
  - Bootstrap
  - Alertify.js
- **Ek Bağımlılıklar**:
  - Reactstrap
  - FontAwesome
  - SignalR

---

## 🔑 **Özellikler**

1. **Kullanıcı Girişi (Login)**
   - **Backend Endpoint**: `https://localhost:7118/api/users/login`
   - **İstek Body**:
     ```json
     {
       "email": "user1@gmail.com",
       "password": "user123"
     }
     ```
   - **Örnek Akış**:
     ![Login Akışı](https://prod-files-secure.s3.us-west-2.amazonaws.com/a739d642-54d0-47ae-9406-03c1eecb017b/279da673-c254-46c8-ad4b-82a835e63788/image.png)

2. **Kayıt Olma (Register)**
   - **Backend Endpoint**: `https://localhost:7118/api/users/register`
   - **İstek Body**:
     ```json
     {
       "fullName": "ömer yılmaz",
       "userName": "omerossssss",
       "email": "omerosdeneme@gmail.com",
       "password": "courseapp77",
       "confirmPassword": "courseapp77",
       "phoneNumber": "5555555555"
     }
     ```
   - **Örnek Akış**:
     ![Register Akışı](https://prod-files-secure.s3.us-west-2.amazonaws.com/a739d642-54d0-47ae-9406-03c1eecb017b/5991ed2f-016b-4419-befb-d699806d1c79/NP51pjCm48NtFiNetv1S8LbGH96AAXQmG49YCwcTOkACgx5TAHo6dY4RLjqrlHVZDeNqVml7YkRDUr-o2X4vfjwfsqMfQfkSGvh6tJH2XyCqHj26ZBQrghwYinh3uCaXW_RJYPCCQndjf_5jhMmBnNhnkeJumn0Kcxo8ImMYwhsdrjbTX27dH37honyPUhd-jYqRPnZIaAwdFWs.svg)

3. **Kurs Yönetimi**
   - **Kurs Oluşturma**:
     - **Backend Endpoint**: `https://localhost:7118/api/courses`
     - **Frontend Akışı**:
       ![Kurs Oluşturma](https://prod-files-secure.s3.us-west-2.amazonaws.com/a739d642-54d0-47ae-9406-03c1eecb017b/4e2c0371-f597-4636-aa3b-53dd46deb1f3/image.png)

4. **Sipariş Yönetimi**
   - **Sipariş Oluşturma**:
     ```bash
     curl -X 'POST' \
       'https://localhost:7118/api/orders' \
       -H 'Authorization: Bearer <Access_Token>' \
       -d '{
         "courseId": "B6C8E7D9-2E4B-4C3F-98F7-7E6B9C4A9D8F"
       }'
     ```
     - **Frontend Görünümü**:
       ![Create Order](https://prod-files-secure.s3.us-west-2.amazonaws.com/a739d642-54d0-47ae-9406-03c1eecb017b/9267d85a-dee4-4c0c-ae14-313ca21e3a69/image.png)

5. **Ödeme İşlemleri**
   - **Ödeme Başlatma**:
     ```bash
     curl -X 'POST' \
       'https://localhost:7118/api/payments' \
       -H 'Authorization: Bearer <Access_Token>' \
       -d '{
         "cardHolderName": "ömer yılmaz",
         "cardNumber": "5890040000000016",
         "expireMonth": "12",
         "expireYear": "2026",
         "cvc": "855",
         "courseId": "B6C8E7D9-2E4B-4C3F-98F7-7E6B9C4A9D8F"
       }'
     ```
   - **3DS İşlemi**:
     - SMS doğrulama ile ödeme tamamlanır.

---

## 📥 **Kurulum ve Çalıştırma**
### **Backend Kurulumu**
1. **Redis Kurulumu**:
   ```bash
   docker run -d --name redis-server -p 6379:6379 redis
   ```
   ```json
     {
  "ConnectionStrings": {
    "Database": "Server=(localdb)\\omer;Database=CourseApp;Trusted_Connection=True;"
  }
}

     ```

2. **Frontend**:
   - Projeyi indirip `npm install` komutunu çalıştırın.
   - Uygulamayı başlatmak için: `npm start`.

---

## 🛠 **Katkıda Bulunma**
1. Projeyi fork edin.
2. Yeni bir dal oluşturun: `git checkout -b feature/yenilik`.
3. Değişikliklerinizi yapın ve commitleyin: `git commit -m 'Yeni özellik'`.
4. Dalınızı gönderin: `git push origin feature/yenilik`.
5. Bir **Pull Request** oluşturun.
