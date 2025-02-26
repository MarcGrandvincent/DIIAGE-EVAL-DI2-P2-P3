Pour appliquer la migration EF Core, changez d'abord le connection 
string dans le appsettings. Ouvrez ensuite un terminal et mettez vous dans le dossier 
"Diiage.Eval.Back.Peristence"

et faite cette commande :
"dotnet ef database update --project ..\Diiage.Eval.Back.Persistence.Migrations --startup-project ..\Diiage.Eval.Back.Api -- --provider SqlServer"

la migration devrait se faire.

cle de l'api : 123 

il faut avoir un instance SQL Server
le projet back et le projet front lance pour que tout marche.