# ☕ Kafe API

Kafe işletmeleri için hazırlanmış **RESTful API** projesi.  
Modern mimari prensipler ve güçlü teknolojiler kullanılarak geliştirildi.  

---

## 🚀 Kullanılan Teknolojiler

- ✅ **.NET Core 9** – Modern, hızlı ve güvenli backend geliştirme altyapısı  
- ✅ **Onion Architecture** – Katmanlı ve sürdürülebilir mimari yaklaşım  
- ✅ **Serilog** – Esnek loglama altyapısı  
- ✅ **AutoMapper** – Nesneler arası kolay veri dönüşümü  
- ✅ **Scalar UI** – API dokümantasyonu ve test arayüzü  
- ✅ **Postman** – API test ve senaryo kontrolü  
- ✅ **FluentValidation** – Veri doğrulama (Validation) yönetimi  
- ✅ **Identity** – Kullanıcı kimlik yönetimi  
- ✅ **JWT (Json Web Token)** – Yetkilendirme ve güvenli erişim  
- ✅ **Rate Limiting** – API güvenliği ve istek sınırlandırma  
- ✅ **RESTful API Prensipleri** – Standartlara uygun API tasarımı  

---

## 📂 Proje Mimarisi
📦 KafeAPI  
┣ 📂 Core  
┃ ┣ 📂 `KafeAPI.Domain` → Entity’ler ve domain kuralları   
┃ ┗ 📂 `KafeAPI.Application` → DTO’lar, servis arayüzleri/iş kuralları, AutoMapper, FluentValidation  
┣ 📂 Infrastructure  
┃ ┗ 📂 `KafeAPI.Persistence` → EF Core `DbContext`, Migrations, Repository implementasyonları, Serilog middleware  
┗ 📂 Presentation  
　┗ 📂 `KafeAPI.API` → Controller’lar, `Program.cs`, kimlik/JWT, Rate Limiting, Scalar UI 

---

## 🖼️ Proje Görseli
<img width="2844" height="1586" alt="Kafe API Scalar " src="https://github.com/user-attachments/assets/6c5a170d-1cc6-4ea4-857f-741b9cbb5ab8" />
