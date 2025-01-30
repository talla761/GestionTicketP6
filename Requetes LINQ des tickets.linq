<Query Kind="Statements">
  <Connection>
    <ID>6b369026-b9c4-49b6-a6ed-694fd275d64d</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>PCYVAN\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>GestionTicketP6</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
      <ExtraCxOptions>Server=PCYVAN\SQLEXPRESS;Database=GestionTicketP6;Trusted_Connection=True;</ExtraCxOptions>
    </DriverData>
  </Connection>
</Query>

// Parametres
string statutRecherche = "Résolu"; // Paramètre pour le statut
int produitRecherche = 1; // Paramètre pour le produit
double versionRecherche = 1.0; // Paramètre pour la version
DateTime dateDebut = new DateTime(2023, 1, 1); // Paramètre pour le début de la période
DateTime dateFin = new DateTime(2024, 12, 31); // Paramètre pour la fin de la période
List<string> motsCles = new List<string> { "Erreur", "lance", "utilisateurs", "plante", "sauvegarde" }; // Liste des mots-clés à rechercher

// 1-Obtenir tous les problèmes en cours (tous les produits) // Obtenir tous les problèmes résolus (tous les produits) 
Tickets
    .Where(t => t.Statut == statutRecherche) // Utilisation du paramètre
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { p.Id, p.Nom }) // Jointure avec Produits
    .Distinct() // Évite les doublons 
    .Dump(); // Affiche les résultats dans LINQPad
	
// 2-Obtenir tous les problèmes en cours pour un produit (toutes les versions) // Obtenir tous les problèmes résolus pour un produit (toutes les versions) 
Tickets
    .Where(t => t.Statut == statutRecherche) // Filtre sur le statut
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { tv.VersionId, tv.NumeroVersion }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad
	
// 3-Obtenir tous les problèmes en cours pour un produit (une seule version) // Obtenir tous les problèmes résolus pour un produit (une seule version) 
Tickets
    .Where(t => t.Statut == statutRecherche && t.IdVersion == versionRecherche) // Filtre sur le statut
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { tv.VersionId, tv.NumeroVersion }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad

// 4-Obtenir tous les problèmes rencontrés au cours d’une période donnée pour un produit (toutes les versions) 
Tickets
    .Where(t => t.DateCreation >= dateDebut && t.DateCreation <= dateFin) // Filtre sur les tickets dans la période donnée
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { tv.VersionId, tv.NumeroVersion }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad
	
// 5-Obtenir tous les problèmes rencontrés au cours d’une période donnée pour un produit (une seule version) 
Tickets
    .Where(t => t.DateCreation >= dateDebut && t.DateCreation <= dateFin && t.IdVersion == versionRecherche) // Filtre sur les tickets dans la période donnée
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { tv.VersionId, tv.NumeroVersion }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad
	
// 6-Obtenir tous les problèmes résolus au cours d’une période donnée pour un produit (toutes les versions) 
Tickets
    .Where(t => t.Statut == "Résolu" && t.DateCreation >= dateDebut && t.DateCreation <= dateFin) // Filtre sur les tickets résolus dans la période donnée
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { tv.VersionId, tv.NumeroVersion }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad
	
// 7-Obtenir tous les problèmes résolus au cours d’une période donnée pour un produit (une seule version)
Tickets
    .Where(t => t.Statut == "Résolu" && t.DateCreation >= dateDebut && t.DateCreation <= dateFin && t.IdVersion == versionRecherche) // Filtre sur les tickets résolus dans la période donnée
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { tv.VersionId, tv.NumeroVersion }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad
	
// 8-Obtenir tous les problèmes en cours contenant une liste de mots-clés (tous les produits) // Obtenir tous les problèmes résolus contenant une liste de mots-clés (tous les produits) 
Tickets
    .Where(t => t.Statut == statutRecherche && motsCles.Contains(t.Probleme)) // Utilisation du paramètre
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { p.Id, p.Nom }) // Jointure avec Produits
	.Select(p => new {
        p.Id, 
		p.Nom 
    }) // Projection des colonnes finales
    .Distinct() // Évite les doublons 
    .Dump(); // Affiche les résultats dans LINQPad
	
// 9-Obtenir tous les problèmes en cours pour un produit contenant une liste de mots-clés (toutes les versions) // Obtenir tous les problèmes résolus pour un produit contenant une liste de mots-clés (toutes les versions)  
Tickets
    .Where(t => t.Statut == statutRecherche && motsCles.Contains(t.Probleme)) // Filtre sur le statut
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id, tv.t.Probleme }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { 
		tv.VersionId, 
		tv.NumeroVersion 
	}) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad

// 10-Obtenir tous les problèmes en cours pour un produit contenant une liste de mots-clés (une seule version)  // Obtenir tous les problèmes résolus pour un produit (une seule version)-Obtenir tous les problèmes résolus pour un produit contenant une liste de mots-clés (une seule version) 
Tickets
    .Where(t => t.Statut == statutRecherche && t.IdVersion == versionRecherche && motsCles.Contains(t.Probleme)) // Filtre sur le statut
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { tv.VersionId, tv.NumeroVersion }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad
	
// 11-Obtenir tous les problèmes rencontrés au cours d’une période donnée pour un produit contenant une liste de mots-clés (toutes les versions)  
Tickets
    .Where(t => t.DateCreation >= dateDebut && t.DateCreation <= dateFin && motsCles.Contains(t.Probleme)) // Filtre sur les tickets dans la période donnée
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { tv.VersionId, tv.NumeroVersion }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad
	
// 12-Obtenir tous les problèmes rencontrés au cours d’une période donnée pour un produit contenant une liste de mots-clés (une seule version) 
Tickets
    .Where(t => t.DateCreation >= dateDebut && t.DateCreation <= dateFin && t.IdVersion == versionRecherche && motsCles.Contains(t.Probleme)) // Filtre sur les tickets dans la période donnée
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { tv.VersionId, tv.NumeroVersion }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad
	
// 13-Obtenir tous les problèmes résolus au cours d’une période donnée pour un produit contenant une liste de mots-clés (toutes les versions)   
Tickets
    .Where(t => t.Statut == "Résolu" && t.DateCreation >= dateDebut && t.DateCreation <= dateFin && motsCles.Contains(t.Probleme)) // Filtre sur les tickets dans la période donnée
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { tv.VersionId, tv.NumeroVersion }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad
	
// 14-Obtenir tous les problèmes résolus au cours d’une période donnée pour un produit contenant une liste de mots-clés (une seule version) 
Tickets
    .Where(t => t.Statut == "Résolu" && t.DateCreation >= dateDebut && t.DateCreation <= dateFin && t.IdVersion == versionRecherche && motsCles.Contains(t.Probleme)) // Filtre sur les tickets dans la période donnée
    .Join(Versions, 
          t => t.IdVersion, 
          v => v.Id, 
          (t, v) => new { t, v }) // Jointure Tickets avec Versions
    .Join(Produits, 
          tv => tv.v.IdProduit, 
          p => p.Id, 
          (tv, p) => new { VersionId = tv.v.Id, NumeroVersion = tv.v.NumeroVersion, ProduitId = p.Id }) // Jointure Versions avec Produits
    .Where(tv => tv.ProduitId == produitRecherche) // Filtre sur le produit
    .Select(tv => new { tv.VersionId, tv.NumeroVersion }) // Sélection des colonnes nécessaires
    .Distinct() // Évite les doublons
    .Dump(); // Affiche les résultats dans LINQPad