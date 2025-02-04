# BlogApp

Ce projet est une application WPF pour gérer des utilisateurs et des blogs via une API REST. Elle est connectée à une base de données MySQL hébergée sur une machine virtuelle (VM) Ubuntu Server.

---

## Configuration du Projet

### **1. Machine Virtuelle**
- La base de données MySQL est hébergée sur une VM Ubuntu Server.
- **Note importante** : L'adresse IP de la VM peut changer. Assurez-vous de mettre à jour l'adresse IP dans le fichier `BlogContext`.

---

### **2. Fichier BlogContext**
Le fichier `BlogContext` contient les informations de connexion à la base de données MySQL. Voici un exemple des paramètres :

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseMySQL("Server=<IP_VM>;Port=3306;Database=BlogDb;User=<username>;Password=<password>;", new MySqlServerVersion(new Version(8, 0, 40)));
}
