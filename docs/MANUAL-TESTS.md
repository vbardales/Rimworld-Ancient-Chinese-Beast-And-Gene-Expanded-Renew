# Tests manuels M1 à M9 (à faire par Virginie)

Ce que la suite Pickle ne peut pas jouer (raison détaillée dans `Tests/Pickle/README.md`, section des exceptions
manuelles). `tested` attend que les neuf soient verts. Préparation commune : une partie de test en mode développeur,
mod actif avec Biotech et Harmony ; le menu debug a une catégorie **Ancient Chinese Beast** (« Bêtes chinoises
antiques » en français) : *Beast attack now*, *Nian beast next hour*, *Clear the sixty-day gate*, *Report the beast clock*.
Le journal (`Player.log`) se lit avec la touche de la console ou dans le dossier du jeu. Noter pour chaque test : vert,
rouge, et ce qui a été vu.

| # | À faire | Attendu |
|---|---|---|
| M1 | Un champ cultivé et un arbre de chaque sorte (dont anima, Gauranlen, polux). Lancer *Beast attack now* jusqu'à ce que le mingshe arrive, attendre une heure de jeu. | Les plantes pourrissent chaque heure tant que la bête vit ; anima, Gauranlen et polux sont épargnés. La sécheresse s'arrête à sa mort. |
| M2 | Un mingshe hostile, un tireur hors de son cercle de vent, un colon dans le cercle. | Les tirs venus de l'extérieur sont renvoyés, le colon à l'intérieur est coupé. |
| M3 | Un qiongqi hostile face à vingt tirs, puis deux tireurs à des distances différentes. | Environ la moitié des tirs esquivés (motes d'esquive) ; il vole vers le tireur le plus éloigné ; les blessures visent la tête plus souvent. |
| M4 | Une sexie en forme humaine, plusieurs colons dont un très sensible psychiquement, à moins de onze cases. | Les colons dans le cercle se retournent les uns contre les autres au rythme de l'aura. |
| M5 | Une bête nian, un colon enfermé derrière une porte. | La bête défonce la porte pour l'atteindre. |
| M6 | Onglet de recherche **Chinese items** (« Objets chinois ») ; construire l'extracteur, faire porter un cadavre de bête, lancer la facture. | L'onglet s'affiche ; la facture va jusqu'au bout et donne les gènes ou le clone. |
| M7 | Un colon avec chacun des trois gènes de la nian (esquive, dégâts à mains nues doublés, tête plus solide). | Effets visibles dans l'onglet santé et dans le journal de combat. |
| M8 | Sauvegarder, changer la langue (anglais vers français, puis retour), recharger, envoyer la lettre suivante d'une bête. | La lettre est dans la nouvelle langue, dans les deux sens. |
| M9 | Ajouter le mod à une sauvegarde existante ; puis, sur une sauvegarde qui a des bêtes, le retirer. | La sauvegarde s'ouvre dans les deux cas (retirer le mod fait disparaître les bêtes, leurs gènes et le conteur). |
