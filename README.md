# Sygnity_Serwer_API

Serwer stworzony na ASP .NET Core, używając .NET 6.

Posiada dwa endpointy /count (POST), /giveLast (GET):
  - POST (/count) - wyliczanie dat wykonywania "zadania":
      - przykład requesta w formacie JSON:
      - {
          "startDate": "2023-08-01",
          "interval": 1,
          "day": "Pn"
        }
      - przykład responsa w formacie JSON:
      - {
          "count": 5,
          "currentDate": "2023-09-04",
          "firstOccurrence": "2023-08-07",
          "lastOccurrence": "2023-08-29",
          "nextOccurrence": "2023-09-05"
        }
  - GET (/giveLast) - pobranie wyliczonych dat wykonywania "zadania" z poprzedniego zapytania:
      - przykład responsa w formacie JSON:
      - {
          "count": 5,
          "currentDate": "2023-09-04",
          "firstOccurrence": "2023-08-07",
          "lastOccurrence": "2023-08-29",
          "nextOccurrence": "2023-09-05"
        }
