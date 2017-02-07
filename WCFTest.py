import requests
import json

url = "http://10.10.2.73/Team6ADProjectuat/WCF/Service.svc/disbursement/update"
post_fields = [
      {
        "Actualquantity": 11,
        "Allocatedquantity": 57,
        "Disbursementid": 2,
        "Itemcode": "E002"
      },
      {
        "Actualquantity": 11,
        "Allocatedquantity": 33,
        "Disbursementid": 2,
        "Itemcode": "E005"
      },
      {
        "Actualquantity": 11,
        "Allocatedquantity": 37,
        "Disbursementid": 2,
        "Itemcode": "E020"
      },
      {
        "Actualquantity": 11,
        "Allocatedquantity": 14,
        "Disbursementid": 2,
        "Itemcode": "F034"
      },
      {
        "Actualquantity": 11,
        "Allocatedquantity": 23,
        "Disbursementid": 2,
        "Itemcode": "T020"
      }
    ]

r = requests.post(url,json=post_fields)
r.close()
print(r.text)# == "true")

##from urllib.parse import urlencode
##from urllib.request import Request, urlopen
##
##request = Request(url, urlencode(post_fields).encode())
##json = urlopen(request).read().decode('UTF-8')
##print(json)
