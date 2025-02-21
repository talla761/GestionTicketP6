<Query Kind="Statements">
  <Connection>
    <ID>2bce0286-a08b-41ad-952b-991cda6c41ac</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>PCYVAN\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>GestionTicketP6</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
  <IncludeAspNet>true</IncludeAspNet>
  <IncludeWinSDK>true</IncludeWinSDK>
</Query>

// Parametres
string statutRecherche = "Résolu"; // Paramètre pour le statut
int produitRecherche = 2; // Paramètre pour le produit
string versionRecherche = "2.1"; // Paramètre pour la version
DateTime dateDebut = new DateTime(2022, 1, 1); // Paramètre pour le début de la période
DateTime dateFin = new DateTime(2025, 12, 31); // Paramètre pour la fin de la période
List<string> motsCles = new List<string> { "lance" }; // Liste des mots-clés à rechercher

// 1-Obtenir tous les problèmes en cours (tous les produits) // Obtenir tous les problèmes résolus (tous les produits) 
Tickets
    .Where(t => t.Statut == statutRecherche)
    .Select(tv => new { tv.Id, tv.DateCreation, tv.DateResolution, tv.Statut, tv.Probleme, tv.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad
	
// 2-Obtenir tous les problèmes en cours pour un produit (toutes les versions) // Obtenir tous les problèmes résolus pour un produit (toutes les versions) 
Tickets
    .Where(t => t.Statut == statutRecherche)
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche) // Filtre sur le produit 
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad
	
// 3-Obtenir tous les problèmes en cours pour un produit (une seule version) // Obtenir tous les problèmes résolus pour un produit (une seule version) 
Tickets
    .Where(t => t.Statut == statutRecherche)
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche && tv.v.NumeroVersion == versionRecherche) // Filtre sur le produit et la version
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad

// 4-Obtenir tous les problèmes rencontrés au cours d’une période donnée pour un produit (toutes les versions) 
Tickets
    .Where(t =>t.DateCreation >= dateDebut && t.DateCreation <= dateFin)
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche) // Filtre sur le produit 
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad
	
// 5-Obtenir tous les problèmes rencontrés au cours d’une période donnée pour un produit (une seule version) 
Tickets
    .Where(t =>t.DateCreation >= dateDebut && t.DateCreation <= dateFin)
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche && tv.v.NumeroVersion == versionRecherche) // Filtre sur le produit et la version
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad
	
// 6-Obtenir tous les problèmes résolus au cours d’une période donnée pour un produit (toutes les versions) 
Tickets
    .Where(t => t.Statut == "Résolu" && t.DateCreation >= dateDebut && t.DateCreation <= dateFin)
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche) // Filtre sur le produit 
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad
	
// 7-Obtenir tous les problèmes résolus au cours d’une période donnée pour un produit (une seule version)
Tickets
    .Where(t => t.Statut == "Résolu" && t.DateCreation >= dateDebut && t.DateCreation <= dateFin)
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche && tv.v.NumeroVersion == versionRecherche) // Filtre sur le produit et la version
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad
	
// 8-Obtenir tous les problèmes en cours contenant une liste de mots-clés (tous les produits) // Obtenir tous les problèmes résolus contenant une liste de mots-clés (tous les produits) 
Tickets
    .Where(t => t.Statut == statutRecherche)
	.AsEnumerable()
	.Where(t => motsCles.All(m => t.Probleme.Contains(m))) // Filtre sur les mots clés
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions 
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad
	
// 9-Obtenir tous les problèmes en cours pour un produit contenant une liste de mots-clés (toutes les versions) // Obtenir tous les problèmes résolus pour un produit contenant une liste de mots-clés (toutes les versions)  
Tickets
    .Where(t => t.Statut == statutRecherche)
	.AsEnumerable()
	.Where(t => motsCles.All(m => t.Probleme.Contains(m))) // Filtre sur les mots clés
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche) // Filtre sur le produit 
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad

// 10-Obtenir tous les problèmes en cours pour un produit contenant une liste de mots-clés (une seule version)  // Obtenir tous les problèmes résolus pour un produit (une seule version)-Obtenir tous les problèmes résolus pour un produit contenant une liste de mots-clés (une seule version) 
Tickets
    .Where(t => t.Statut == statutRecherche)
	.AsEnumerable()
	.Where(t => motsCles.All(m => t.Probleme.Contains(m))) // Filtre sur les mots clés
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche && tv.v.NumeroVersion == versionRecherche) // Filtre sur le produit et la version
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad
	
//// 11-Obtenir tous les problèmes rencontrés au cours d’une période donnée pour un produit contenant une liste de mots-clés (toutes les versions)  
Tickets
    .Where(t =>t.DateCreation >= dateDebut && t.DateCreation <= dateFin)
	.AsEnumerable()
	.Where(t => motsCles.All(m => t.Probleme.Contains(m))) // Filtre sur les mots clés
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche) // Filtre sur le produit 
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad
	
//// 12-Obtenir tous les problèmes rencontrés au cours d’une période donnée pour un produit contenant une liste de mots-clés (une seule version) 
Tickets
    .Where(t =>t.DateCreation >= dateDebut && t.DateCreation <= dateFin)
	.AsEnumerable()
	.Where(t => motsCles.All(m => t.Probleme.Contains(m))) // Filtre sur les mots clés
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche && tv.v.NumeroVersion == versionRecherche) // Filtre sur le produit et la version
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad
	
//// 13-Obtenir tous les problèmes résolus au cours d’une période donnée pour un produit contenant une liste de mots-clés (toutes les versions)   
Tickets
    .Where(t => t.Statut == "Résolu" && t.DateCreation >= dateDebut && t.DateCreation <= dateFin)
	.AsEnumerable()
	.Where(t => motsCles.All(m => t.Probleme.Contains(m))) // Filtre sur les mots clés
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche) // Filtre sur le produit 
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad
	
// 14-Obtenir tous les problèmes résolus au cours d’une période donnée pour un produit contenant une liste de mots-clés (une seule version) 
Tickets
    .Where(t => t.Statut == "Résolu" && t.DateCreation >= dateDebut && t.DateCreation <= dateFin)
	.AsEnumerable()
	.Where(t => motsCles.All(m => t.Probleme.Contains(m))) // Filtre sur les mots clés
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
	.Where(tv => tv.v.IdProduit == produitRecherche && tv.v.NumeroVersion == versionRecherche) // Filtre sur le produit et la version
    .Select(tv => new { tv.t.Id, tv.t.DateCreation, tv.t.DateResolution, tv.t.Statut, tv.t.Probleme, tv.t.Resolution }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
	.ToList()
    .Dump(); // Affiche les résultats dans LINQPad