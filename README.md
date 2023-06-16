## Api Veterinaria
Este es un proyecto de ejemplo de creacion de apis Restfull,
se creo usando .NET 6 usando Entity Framework en modo Codefirst
# requisitos
para poder usar la aplicacion es necesario tener instalada una instancia de MS-SQL server
# comandos utiles
para usar entity framework es necesario ejecutar los siguientes comandos en la cosola del administrador de paquetes:
*dotnet tool install --global dotnet-ef : para instalar entity framework
*dotnet tool update --global dotnet-ef  : para actualizar la instalacion
*Add-Migration InitialCreate : para hacer la primera configuracion/migracion
*Update-Database : para crear/actualizar la BD
*drop-database : para eliminar la BD
*Remove-Migration : para eliminar las migraciones (util para poder regenear la BD)


