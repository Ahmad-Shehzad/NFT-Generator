import sqlite3

class Database:
    def __init__(self, dbName):
        self.dbName = dbName
        self.con = sqlite3.connect('C://NFT_DATABASES/' + dbName +'.db')

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
        pdb.gimp_file_save(newImage, newImage.layers[0], '#' + str(fileName) + '.png', '?')
        pdb.gimp_image_delete(newImage)

    def getLayerNames(self):
        names = []
        for layer in self.layers:
            names.append(layer.name)
        
        return names

    def createImages(self, min, max):
        db = Database(self.dbName)
        layerNames = self.getLayerNames()
        if max > db.getCount():
            raise Exception("Your max value exceeds the entries in your table")
        for i in range(min, max + 1):
            nft = db.getNFT(i)
            for x in nft:
                self.layers[layerNames.index(x + ".PNG")].visible = True
            self.save(self.image, i)
            self.clear()

