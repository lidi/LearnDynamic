import os

import requests

API_TOKEN = "ef4e7575c98b3686e476089f2f15cfa762ca2168"
API_URL = "https://api.github.com/user/repos"

url = "{}?access_token={}".format(API_URL, API_TOKEN)
req_json = requests.get(url).json()

for repo in req_json:
    print repo['git_url']


