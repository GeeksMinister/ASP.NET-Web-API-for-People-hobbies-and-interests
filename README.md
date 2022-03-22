## Labb4_API

### 1- [Get] all people
https://localhost:7098/api/Labb4_API_/AllPeople
```
[
    {
        "id": 1,
        "firstName": "Martelle",
        "lastName": "Woodyer",
        "age": 29,
        "phone": "+30 728 979 6883",
        "city": "Kompóti",
        "email": "mwoodyer0@bing.com"
    },
    {
        "id": 2,
        "firstName": "Uri",
        "lastName": "Belsher",
        "age": 25,
        "phone": "+351 529 141 8155",
        "city": "Macedo de Cavaleiros",
        "email": "ubelsher1@constantcontact.com"
    },
    {
        "id": 3,
        "firstName": "Beltran",
        "lastName": "Spracklin",
        "age": 40,
        "phone": "+86 332 876 7195",
        "city": "Guantouzui",
        "email": "bspracklin2@tinypic.com"
    },
    {
        "id": 4,
        "firstName": "Fannie",
        "lastName": "Dufaur",
        "age": 21,
        "phone": "+506 854 695 4887",
        "city": "Esquipulas",
        "email": "fdufaur3@a8.net"
    },
    {
        "id": 5,
        "firstName": "Eda",
        "lastName": "Lumsdon",
        "age": 38,
        "phone": "+51 376 577 9599",
        "city": "Chinchaypujio",
        "email": "elumsdon4@google.com.hk"
    },
    {
        "id": 6,
        "firstName": "Britt",
        "lastName": "Hassell",
        "age": 31,
        "phone": "+964 389 401 8494",
        "city": "Ad Diwaniyah",
        "email": "bhassell5@ted.com"
    },
    {
        "id": 7,
        "firstName": "Simeon",
        "lastName": "Marquot",
        "age": 50,
        "phone": "+55 136 758 8081",
        "city": "Taboão da Serra",
        "email": "smarquot6@baidu.com"
    },
    {
        "id": 8,
        "firstName": "Garold",
        "lastName": "Lichtfoth",
        "age": 34,
        "phone": "+48 544 283 7852",
        "city": "Wola Uhruska",
        "email": "glichtfoth7@facebook.com"
    },
    {
        "id": 9,
        "firstName": "Malory",
        "lastName": "Odney",
        "age": 34,
        "phone": "+46 697 444 1016",
        "city": "Gislaved",
        "email": "modney8@alibaba.com"
    },
    {
        "id": 10,
        "firstName": "Paulie",
        "lastName": "Braybrooke",
        "age": 35,
        "phone": "+63 803 900 0554",
        "city": "Sinacaban",
        "email": "pbraybrooke9@paginegialle.it"
    }
]

```

### 2- [Get] all interests that are linked to a specific person 
https://localhost:7098/api/Labb4_API_/GetInterestsByPersonId?personId=4 
```
[
    {
        "id": 12,
        "title": "Senior Editor",
        "description": "Fusion Occip Jt w Autol Sub, Post Appr A Col, Perc",
        "personId": 4
    },
    {
        "id": 16,
        "title": "Quality Control Specialist",
        "description": "Drainage of Left Hepatic Duct, Perc Endo Approach",
        "personId": 4
    },
    {
        "id": 23,
        "title": "string",
        "description": "string",
        "personId": 4
    }
]
```
### 3- [Get] all links that are linked to a specific person
https://localhost:7098/api/Labb4_API_/GetLinksByPersonId?personId=7
```
[
    {
        "id": 9,
        "url": "https://phoca.cz",
        "personId": 7,
        "interestId": 19
    },
    {
        "id": 21,
        "url": "https://squidoo.com",
        "personId": 7,
        "interestId": 5
    },
    {
        "id": 25,
        "url": "http://constantcontact.com",
        "personId": 7,
        "interestId": 16
    },
    {
        "id": 29,
        "url": "https://cnn.com",
        "personId": 7,
        "interestId": 10
    },
    {
        "id": 31,
        "url": "http://ucoz.ru",
        "personId": 7,
        "interestId": 11
    },
    {
        "id": 39,
        "url": "http://who.int",
        "personId": 7,
        "interestId": 15
    }
]
```
### 4- [Post] a new interest to a person
https://localhost:7098/api/Labb4_API_/AddInterest
{
  "title": "from Postman",
  "description": "string",
  "personId": 4
}
```
{
    "id": 39,
    "title": "from Postman",
    "description": "string",
    "personId": 4
}
```
### 5- [Post] new links for a specific person and a specific interest
https://localhost:7098/api/Labb4_API_/AddLink
{
    "url": "https://Postmanssss.com",
    "personId": 7,
    "interestId": 10
}
```
{
    "id": 60,
    "url": "https://Postmanssss.com",
    "personId": 7,
    "interestId": 10
}
```
### 6- [Get] all the interests and all links for that person directly in a hierarchical JSON file 
https://localhost:7098/api/Labb4_API_/GetAllInfoForPerson?personId=9
```
{
  "id": 9,
  "firstName": "Malory",
  "lastName": "Odney",
  "age": 34,
  "phone": "+46 697 444 1016",
  "city": "Gislaved",
  "email": "modney8@alibaba.com",
  "interests": [
    {
      "id": 17,
      "title": "Environmental Specialist",
      "description": "Release Left Internal Mammary Lymphatic, Open Approach",
      "personId": 9,
      "links": [
        {
          "id": 49,
          "url": "http://bloomberg.com/vulputate/elementum/nullam/varius/nulla.json",
          "personId": 9,
          "interestId": 17
        },
        {
          "id": 50,
          "url": "https://bigcartel.com/lectus/in/est.json",
          "personId": 9,
          "interestId": 17
        },
        {
          "id": 51,
          "url": "http://theglobeandmail.com/non/quam/nec/dui.js",
          "personId": 9,
          "interestId": 17
        }
      ]
    },
    {
      "id": 18,
      "title": "Senior Financial Analyst",
      "description": "Destruction of Thoracic Sympathetic Nerve, Perc Approach",
      "personId": 9,
      "links": [
        {
          "id": 52,
          "url": "http://washingtonpost.com/quis/orci/nullam/molestie/nibh.aspx",
          "personId": 9,
          "interestId": 18
        },
        {
          "id": 53,
          "url": "https://vk.com/eget/elit/sodales/scelerisque.js",
          "personId": 9,
          "interestId": 18
        },
        {
          "id": 54,
          "url": "https://quantcast.com/odio/odio/elementum/eu/interdum.png",
          "personId": 9,
          "interestId": 18
        }
      ]
    }
  ]
}
```
### 7- [Get] people from a name search 
https://localhost:7098/api/Labb4_API_/SearchForPerson?search=ar
```
[
  {
    "id": 1,
    "firstName": "Martelle",
    "lastName": "Woodyer",
    "age": 29,
    "phone": "+30 728 979 6883",
    "city": "Kompóti",
    "email": "mwoodyer0@bing.com"
  },
  {
    "id": 7,
    "firstName": "Simeon",
    "lastName": "Marquot",
    "age": 50,
    "phone": "+55 136 758 8081",
    "city": "Taboão da Serra",
    "email": "smarquot6@baidu.com"
  },
  {
    "id": 8,
    "firstName": "Garold",
    "lastName": "Lichtfoth",
    "age": 34,
    "phone": "+48 544 283 7852",
    "city": "Wola Uhruska",
    "email": "glichtfoth7@facebook.com"
  }
]
```
### 8-
