# SeriousChallenge
1.  Run application via Kestrel. (cmd dotnet run)


2.  When it runs, it directly redirects to http://url:port/swagger


3.  Api has /Market/compare url and it accepts symbol and comparison

![initial preview](https://github.com/TuralSuleymani/SeriousChallenge/blob/main/github2.PNG)


## Example json response:

```json
{
  "comparisonItems": [
    {
      "date": "2021-07-26T17:30:00+04:00",
      "timeStamp": 1627306200,
      "source": {
        "symbol": "MSFT",
        "performance": "100.00%"
      },
      "opposite": {
        "symbol": "SPY",
        "performance": "100.00%"
      }
    },
    {
      "date": "2021-07-26T17:30:00+04:00",
      "timeStamp": 1627392600,
      "source": {
        "symbol": "MSFT",
        "performance": "100.15%"
      },
      "opposite": {
        "symbol": "SPY",
        "performance": "100.14%"
      }
    },
    {
      "date": "2021-07-26T17:30:00+04:00",
      "timeStamp": 1627392600,
      "source": {
        "symbol": "MSFT",
        "performance": "100.00%"
      },
      "opposite": {
        "symbol": "SPY",
        "performance": "100.08%"
      }
    },
    {
      "date": "2021-07-26T17:30:00+04:00",
      "timeStamp": 1627392600,
      "source": {
        "symbol": "MSFT",
        "performance": "99.04%"
      },
      "opposite": {
        "symbol": "SPY",
        "performance": "100.12%"
      }
    },
    {
      "date": "2021-07-26T17:30:00+04:00",
      "timeStamp": 1627392600,
      "source": {
        "symbol": "MSFT",
        "performance": "98.67%"
      },
      "opposite": {
        "symbol": "SPY",
        "performance": "99.68%"
      }
    }
  ]
}
```