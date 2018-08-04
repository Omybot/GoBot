Le précision des calculs (et principalement pour valider une proximité ou comparer des données très proches) est volontairement bridée.
La constante RealPoint.PRECISION est à utiliser partout où on veut utiliser cette marge de précision. (Tests d'égalité, Tests unitaires, etc)

IShape.GetCrossingPoints 
	- Retourne une liste exhaustive et non dupliquée des croisements entre les deux formes.
	- Si les formes ne se croisent pas, le résultat attendu est une liste vide.
	- En cas de forme identique, le comportement est à définir par le concepteur, mais la liste doit contenir au minimum un point.

IShape.Contains
	- Une forme contient forcément une forme identique

IShape.Cross
	- Doit être utilisé plutôt que de tester si GetCrossingPoints retourne une liste vide
	- Est implémenté le plus simplement possible, pour être moins couteux à l'appel que GetCrossingPoints

IShape.Distance
	- Retourne la distance entre les deux points les plus proches du contour des deux formes concernées
	- Retourne 0 si les formes se croisent
	- Retourne 0 si les formes se contiennent