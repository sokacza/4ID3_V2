import pymongo

f = open("parsedDb.csv", 'w+')
myclient = pymongo.MongoClient("mongodb://localhost:27017/")

groupName = input("Group Name: ")
deviceId = input("Device Id: ")

mydb = myclient[groupName]
mycollection = mydb[deviceId]

documents = mycollection.find({})

print("Temperature, Luminosity", file = f)

for doc in documents:
    print(f"{doc['Temp']}, {doc['Luminosity']}", file=f)

f.close()
