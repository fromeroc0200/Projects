/*Database Validation*/
IF EXISTS ( SELECT name FROM master.dbo.sysdatabases WHERE name = N'BikeStores')
BEGIN
    SELECT 'Database BikeStores already Exist' AS Message
END
ELSE
BEGIN
    CREATE DATABASE [BikeStores]
    SELECT 'New Database BikeStores is Created'
END