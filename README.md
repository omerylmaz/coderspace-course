# Final Projesi - Backend ve Frontend Entegrasyonu

---

## 📜 **Projenin Genel Akışı ve Entity Relationship Diagramı (ERD)**
![image](https://github.com/user-attachments/assets/55203ca8-875c-4aec-bf60-33676a3d0f75)

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
     ![login](https://github.com/user-attachments/assets/c6078c6d-d680-44f3-9295-66e2809af085)


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
     ![register](https://github.com/user-attachments/assets/ecd55572-4337-462d-9ce9-b40477c87f44)

     - **Frontend**:
     ![register-front](https://github.com/user-attachments/assets/5e5cc898-d41c-4fef-9bd0-5b611c537598)


)


3. **Kurs Yönetimi**
   - **Kurs Oluşturma**:
     - **Backend Endpoint**: `https://localhost:7118/api/courses`
     - **Akış**:
       ![NP51pjCm48NtFiNetv1S8LbGH96AAXQmG49YCwcTOkACgx5TAHo6dY4RLjqrlHVZDeNqVml7YkRDUr-o2X4vfjwfsqMfQfkSGvh6tJH2XyCqHj26ZBQrghwYinh3uCaXW_RJYPCCQndjf_5jhMmBnNhnkeJumn0Kcxo8ImMYwhsdrjbTX27dH37honyPUhd-jYqRPnZIaAwdFWs](https://github.com/user-attachments/assets/2639c4fe-038c-46b0-8de5-04eb28d8bd12)

       - **Frontend Akışı**:
       ![createcourse-front](https://github.com/user-attachments/assets/916d54c6-4847-4bb8-bf3b-1783eeecea45)



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
     - **Akış**:
       ![createorder](https://github.com/user-attachments/assets/d589155d-3696-4c00-844c-82b614b1e93d)

     - **Frontend Görünümü**:
       ![createorder-front](https://github.com/user-attachments/assets/9af9da09-29d4-4bdf-b7e7-e033719620e8)


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
