# Application Galerie d'Art Virtuelle

Bienvenue dans l'Application Galerie d'Art Virtuelle ! Ce projet vous permet de gérer et d'explorer des œuvres d'art stockées en formats JSON et XML, offrant des fonctionnalités telles que l'affichage, la recherche avancée, le tri, la transformation de données, et plus encore.

## Pourquoi LINQ ?

LINQ (Language Integrated Query) est utilisé de manière extensive dans ce projet pour sa capacité à interroger et manipuler les données de manière concise et lisible. Il simplifie les opérations sur les collections, offrant des capacités de requêtage puissantes directement dans le code C#.

### Principaux avantages de LINQ :
- **Simplicité :** Offre une syntaxe déclarative pour interroger et manipuler les données, rendant le code plus intuitif.
- **Lisibilité :** Améliore la lisibilité du code en abstrayant les boucles complexes et la logique conditionnelle.
- **Intégration :** Intègre de manière transparente les capacités de requêtage directement dans le langage C#, améliorant la productivité des développeurs.

## Pour Commencer

Pour exécuter l'Application Galerie d'Art Virtuelle en local, suivez ces étapes :

### Prérequis
- .NET Core SDK (version 3.1 ou supérieure)
- IntelliJ Rider (recommandé, IDE utilisé pour créer le projet), Visual Studio ou tout autre éditeur de texte

### Installation

1. Clonez le repository sur votre machine locale :
   ```bash
   git clone https://github.com/Manonrtnt/ArtGalleryApp.git
   ```

2. Naviguez jusqu'au répertoire du projet :
   ```bash
   cd ArtGalleryApp_LinQ_project
   ```

3. Ouvrez le projet dans Rider ou Visual Studio.
- ouvrir le fichier de solution de projet : ArtGalleryApp.sln

4. Restaurez les packages NuGet si nécessaires :
   - Newtonsoft.Json : Ce package est utilisé pour la sérialisation et désérialisation JSON.

   ```bash
   dotnet restore
   ```

### Comment Exécuter

1. Définissez le fichier `Programe.cs` comme fichier de démarrage dans votre IDE.

2. Compilez et exécutez le projet. Vous pouvez utiliser les fonctionnalités intégrées de l'IDE pour exécuter ou déboguer, ou utilisez la commande suivante dans le terminal :

   ```bash
   dotnet run
   ```

## Fonctionnalités et Méthodes LINQ

### 1. Afficher toutes les œuvres d'art

- **Fonctionnalité :** Affiche toutes les œuvres d'art stockées dans la collection.
- **Méthode LINQ :** Utilise une boucle `foreach` pour parcourir la collection `Utils.artworks`.

   ```csharp
   foreach (var artwork in Utils.artworks)
   {
       Console.WriteLine(artwork);
   }
   ```

### 2. Recherche avancée des œuvres d'art

- **Fonctionnalité :** Permet une recherche avancée basée sur le nom de l'artiste, l'année de création ou le style artistique.
- **Méthode LINQ :** Utilise la clause `Where` pour filtrer les œuvres d'art en fonction de l'entrée de l'utilisateur.

   ```csharp
   var artistResults = artworks.Where(a => a.Artist.ToLower().Contains(artistName));
   ```

### 3. Trier les œuvres d'art

- **Fonctionnalité :** Trie les œuvres d'art par titre, artiste, année ou style.
- **Méthode LINQ :** Applique la clause `OrderBy` pour le tri.

   ```csharp
   Utils.artworks = Utils.artworks.OrderBy(a => a.Title).ToList();
   ```

### 4. Transformer les œuvres d'art (JSON vers XML)

- **Fonctionnalité :** Convertit les données des œuvres d'art du format JSON au format XML.
- **Méthode LINQ :** Utilise des requêtes LINQ pour la transformation des données.

   ```csharp
   XDocument xmlOutput = new XDocument(
       new XElement("artworks",
           artworksToTransform.Select(a => XElement.Parse(a.ToXmlString()))
       )
   );
   ```

### 5. Afficher les statistiques des œuvres d'art

- **Fonctionnalité :** Affiche le nombre total d'œuvres d'art actuellement stockées.
- **Méthode LINQ :** Utilise la méthode `Count` pour compter les éléments dans la collection.

   ```csharp
   int totalArtworks = artworks.Count();
   ```

### 6. Ajouter une nouvelle œuvre d'art

- **Fonctionnalité :** Permet aux utilisateurs d'ajouter une nouvelle œuvre d'art à la collection.

### 7. Télécharger JSON

- **Fonctionnalité :** Télécharge les données des œuvres d'art au format JSON vers un répertoire spécifié.

---

## Tester l'application depuis l'exécutable
1. **Accès à l'exécutable**
   - Allez dans le dossier `ArtGalleryApp_LinQ_project\ArtGalleryApp\bin\Release\net8.0\publish`.

2. **Trouver l'exécutable**
   - Vous y trouverez l'exécutable de l'application, par exemple `ArtGalleryApp.exe`.

3. **Lancer l'application**
   - Double-cliquez sur `ArtGalleryApp.exe` pour démarrer l'application.

4. **Utiliser l'application**
   - Explorez les différentes fonctionnalités comme l'affichage des œuvres d'art, les recherches avancées et l'ajout de nouvelles œuvres.

---
