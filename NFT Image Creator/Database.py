import sqlite3

class Database:
    def __init__(self, dbName):
        self.dbName = dbName
        self.con = sqlite3.connect('C://NFT/NFT_DATABASES/' + dbName +'.db')

    def getNFT(self, id):
        stmt = "SELECT * FROM NFT WHERE ID = " + str(id)
        cursor = self.con.cursor()
        cursor.execute(stmt)
        result = list(cursor.fetchall()[0])
        result.pop(0)

        return result
    
    def getCount(self):
        stmt = "SELECT COUNT(ID) FROM NFT"
        cursor = self.con.cursor()
        cursor.execute(stmt)
        result = cursor.fetchone()

        return result[0]

class generateNFT:
    def __init__(self, dbName):
        self.dbName = dbName
        self.image = gimp.image_list()[0]
        self.layers = self.image.layers
        self.clear()
    
    def clear(self):
        for layer in self.layers:
            layer.visible = False

    def save(self, image, fileName):
        newImage = pdb.gimp_image_duplicate(image)
        newImage.flatten()
        pdb.gimp_file_save(newImage, newImage.layers[0], str(fileName) + '.png', '?')
        pdb.gimp_image_delete(newImage)

    def createImages(self):
        db = Database(self.dbName)
        for i in range(1, db.getCount() + 1):
            nft = db.getNFT(i)
            for x in nft:
                for layer in self.layers:
                    if layer.name == x + ".png":
                        layer.visible = True
            self.save(self.image, i)
            self.clear()

