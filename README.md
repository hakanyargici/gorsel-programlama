# Randevu Takip Uygulaması

Bu proje, Görsel Programlama dersinin final ödevi olduğu için oluşturulmuştur. 

Uygulama, Visual Studio 2022 kullanılarak geliştirilen bir Windows Forms uygulamasıdır. Uygulama, SQL Server LocalDB veritabanı ile çalışmaktadır. Bu döküman, projeyi kendi bilgisayarınızda çalıştırabilmeniz için gerekli adımları içerir.

---

## 🔧 Gereksinimler

- Visual Studio 2022 (veya uyumlu bir sürüm)
- .NET Framework yüklü olmalı (projenin hedeflediği versiyon)
- SQL Server LocalDB (Visual Studio ile birlikte gelir)

---

## 📦 Dosya İçeriği

Proje klasöründe aşağıdaki dosyalar yer almaktadır:

- `RandevuTakip/` → Uygulama kaynak kodları (.sln, .cs, .Designer.cs vs.)
- `Database/` → Uygulama kaynak kodları (.sln, .cs, .Designer.cs vs.)
    - `RandevuTakipDB.mdf` → Veritabanı dosyası
    - `RandevuTakipDB.ldf` → Veritabanı log dosyası
- `README.md` → Bu dosya

---

## 🚀 Kurulum Adımları

### 1. Projeyi Açın

Visual Studio ile `RandevuTakip.sln` dosyasını açın.

---

### 2. Veritabanını Tanıtın

1. **Visual Studio** içinde **View > SQL Server Object Explorer** sekmesini açın.
2. Sol menüde `SQL Server > (localdb)\MSSQLLocalDB > Databases` yoluna gidin.
3. `Databases` üzerine sağ tıklayıp **Add Existing Database...** seçeneğini seçin.
4. Bu klasörde bulunan `RandevuTakipDB.mdf` dosyasını seçin ve ekleyin.

---

### 3. Connection String Güncellemesi

Projede kullanılan bağlantı cümlesi (connection string) aşağıdaki şekilde olmalıdır:

```csharp
string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Veritabani\RandevuTakipDB.mdf;Integrated Security=True;";