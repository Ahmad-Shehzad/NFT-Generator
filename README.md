# NFT-Generator
Creates NFTs automatically

Pre-requisites:
- Microsoft SQL Server installed on local machine
- Gimp
- SQL server to SQLite converter

First launch NFT Creator to create database of NFTs.

Convert the database to a sqlite database.

Launch Gimp, add all layers taking care with the order.

Then Filter > Python-Fu > Console

Run the command execfile('path for Database.py')

Create an instance of generateNFT('DATABASE_NAME'):
gen = generateNFT('DATABASE_NAME')
Then call method gen.createImages() and find images under C:\Users\USER_NAME or wherever your gimp project is saved I believe the former is if you have not saved the gimp file.

In the future I hop to make it so you do not need to convert the SQL database.
