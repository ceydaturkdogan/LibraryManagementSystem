# Kütüphane Yönetim Sistemi (Library Management System)

Bu proje, bir kütüphanenin kitap ve yazar işlemlerini yönetmek amacıyla geliştirilmiş bir ASP.NET Core MVC uygulamasıdır. Bu sistem, OOP (Nesne Yönelimli Programlama) prensiplerine uygun olarak inşa edilmiştir.

## Proje Tanımı

Kütüphane Yönetim Sistemi, kütüphane bünyesindeki kitap ve yazarları yönetmek için kapsamlı bir çözümdür. Uygulama, kitap ekleme, düzenleme, silme işlemlerini içerir ve yazarların da detaylı yönetimini sağlar. Aynı zamanda kullanıcıların sisteme kayıt olmasını ve giriş yapmasını sağlayan bir kullanıcı yönetimi modülü de içerir.

## Proje Gereksinimleri

### 1. Modeller

#### Book Modeli
- **Id**: Benzersiz kimlik (int)
- **Title**: Kitap başlığı (string)
- **AuthorId**: Yazar kimliği (int) - Author modeline referans
- **Genre**: Kitap türü (string)
- **PublishDate**: Yayın tarihi (DateTime)
- **ISBN**: ISBN numarası (string)
- **CopiesAvailable**: Mevcut kopya sayısı (int)

#### Author Modeli
- **Id**: Benzersiz kimlik (int)
- **FirstName**: Yazarın adı (string)
- **LastName**: Yazarın soyadı (string)
- **DateOfBirth**: Yazarın doğum tarihi (DateTime)

#### User Modeli
- **Id**: Benzersiz kimlik (int)
- **FullName**: Üye adı ve soyadı (string)
- **Email**: E-posta adresi (string)
- **Password**: Giriş parolası (string)
- **PhoneNumber**: Telefon numarası (string)
- **JoinDate**: Kayıt tarihi (DateTime)

### 2. ViewModel'ler

#### BookViewModel
Kitap detaylarını göstermek ve kitapların listeleneceği sayfalar için kullanılır.

#### AuthorViewModel
Yazar detaylarını göstermek ve yazarların listeleneceği sayfalar için kullanılır.

#### AuthViewModel
Kullanıcıların kayıt olma ve giriş yapma işlemleri için kullanılır.

### 3. Controller'lar

#### BookController
- **List**: Kitapların listesini görüntüler.
- **Details**: Belirli bir kitabın detaylarını gösterir.
- **Create**: Yeni kitap eklemek için form sağlar.
- **Edit**: Mevcut bir kitabı düzenlemek için form sağlar.
- **Delete**: Kitabı silmek için onay sayfası sağlar.

#### AuthorController
- **List**: Yazarların listesini görüntüler.
- **Details**: Belirli bir yazarın detaylarını gösterir.
- **Create**: Yeni yazar eklemek için form sağlar.
- **Edit**: Mevcut bir yazarı düzenlemek için form sağlar.
- **Delete**: Yazarı silmek için onay sayfası sağlar.

#### AuthController
- **SignUp**: Kayıt işlemini yönetir.
- **Login**: Giriş işlemini yönetir.

### 4. View'ler

#### Kitap Görünümleri
- **List**: Kitapların listelendiği sayfa.
- **Details**: Belirli bir kitabın detaylarını gösteren sayfa.
- **Create**: Yeni kitap ekleme formu.
- **Edit**: Kitap düzenleme formu.

#### Yazar Görünümleri
- **List**: Yazarların listelendiği sayfa.
- **Details**: Belirli bir yazarın detaylarını gösteren sayfa.
- **Create**: Yeni yazar ekleme formu.
- **Edit**: Yazar düzenleme formu.

#### Kullanıcı Görünümleri
- **Sign Up**: Üye kayıt formu, şifre tekrar alanı içerir.
- **Login**: Giriş formu, yanlış girişte hata mesajı gösterir.

### 5. Program.cs Konfigürasyonu
- **MVC Servisleri**: Uygulamanın MVC yapısına uygun olarak konfigüre edilmesi.
- **Statik Dosyalar**: `wwwroot` klasöründeki statik dosyaların kullanımı sağlanır.
- **Routing**: İsteklerin ilgili controller ve aksiyon metodlarına yönlendirilmesi.
- **Varsayılan Routing**: Ana sayfa ve varsayılan routing yapılandırması.
