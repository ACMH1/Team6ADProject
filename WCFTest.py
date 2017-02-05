import requests
import json

url = "http://192.168.1.181/testWCF/Service.svc/Create"
post_fields = {"Category":"Bags","Description":"Pink Balenciaga. Brand New in packagingtest1","ItemID":56,"Price":3000,"Status":1,"Title":"Balenciaga"}
post_field = {"ItemID":2}

r = requests.post(url,json=post_fields)
r.close()
print(r.text)# == "true")

##from urllib.parse import urlencode
##from urllib.request import Request, urlopen
##
##request = Request(url, urlencode(post_fields).encode())
##json = urlopen(request).read().decode('UTF-8')
##print(json)
