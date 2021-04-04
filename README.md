# MoneyAPI
## Building

This is a dll, so you'll need to clone the repository, build-it and add this dll reference to your project.

## How to use

```csharp
var money = new Money(apiKey, Uri);
```

That's the base. This api was based on [currency converter](https://www.currencyconverterapi.com/). So you can get your appropriate apiKey/Uri there.

#### Getting exchange between currencies

```csharp
var money = new Money(apiKey, Uri);
var exchange = money.exchangeCurrencies(from, to)
```

That's return a string that you can convert into double, int, decimal or whatever. The args are the Id of an currency, like "usd", "brl" etc.



You can also get an Enumerable of exchanges, by passing a Dictionary of from_to's (but the free version let you get just 2 exchanges per time):

```csharp
var money = new Money(apiKey, Uri);
var dict = new Dictionary<string, string>();
dict.Add("USD", "BRL");
dict.Add("EUR", "USD");
var results = money.exchangeCurrencies(dict);
```



#### Getting all currency list 

Here you can get all available currencies. It will return an Enumerable with the currency properties.

```csharp
var money = new Money(apiKey, Uri);
var currencies = money.getAllCurrencies();
```



#### Getting all country list 

Here you can an Enumerable of all countries and it's properties

```csharp
var money = new Money(apiKey, Uri);
var countries = money.getAllCountries();
```



