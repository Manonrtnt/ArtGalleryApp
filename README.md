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
- Visual Studio (recommandé) ou tout autre éditeur de texte

### Installation

1. Clonez le repository sur votre machine locale :
   ```bash
   git clone https://github.com/votre-nom/galerie-art-virtuelle.git
   ```

2. Naviguez jusqu'au répertoire du projet :
   ```bash
   cd galerie-art-virtuelle
   ```

3. Ouvrez le projet dans Visual Studio ou votre IDE préféré.

4. Restaurez les packages NuGet nécessaires :
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
- **Méthode LINQ :** Aucune méthode LINQ directement applicable pour cette fonctionnalité.

### 7. Télécharger JSON

- **Fonctionnalité :** Télécharge les données des œuvres d'art au format JSON vers un répertoire spécifié.
- **Méthode LINQ :** Aucune méthode LINQ directement applicable pour cette fonctionnalité.