import firebase_admin
from firebase_admin import firestore

credentials = firebase_admin.credentials.Certificate("./test-67d8c-firebase-adminsdk-ylbeq-e84123180f.json")
firebase_admin.initialize_app(credentials)

db = firebase_admin.firestore.client()
collection = db.collection(u'DeviceA')
documents = collection.get()

# for doc in documents:
    # doc.reference.delete()
    

data = dict({"Temperature": 69, "Humidity": 50})
collection.add(data)
print("--")
documents = collection.get()

for doc in documents:
    print(doc.to_dict())