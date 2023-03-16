import pymongo

myclient = pymongo.MongoClient("mongodb://localhost:27017/")
mydb = myclient["IoT"]
mycollection = mydb["SmartDevices2"]

mydict = { "name": "John", "address": "Highway 77" }

x = mycollection.insert_one(mydict)