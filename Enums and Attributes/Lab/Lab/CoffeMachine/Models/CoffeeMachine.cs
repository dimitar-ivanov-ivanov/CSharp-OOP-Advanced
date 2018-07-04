using System;
using System.Collections.Generic;

public class CoffeeMachine : ICoffeMachine
{
    private int coins;
    private List<CoffeeType> coffeesSold;

    public IEnumerable<CoffeeType> CoffeesSold => coffeesSold;
    public int Coins => coins;

    public CoffeeMachine()
    {
        this.coffeesSold = new List<CoffeeType>();
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeeType coffeeType;
        CoffeePrice coffeePrice;

        if(Enum.TryParse(size,out coffeePrice) &&
           Enum.TryParse(type,out coffeeType))
        {
            if((int)coffeePrice <= coins)
            {
                coins -= 0;
                coffeesSold.Add(coffeeType);
            }
        }
    }

    public void InsertCoin(string coin)
    {
        switch (coin)
        {
            case "One":
                coins += 1;
                break;
            case "Two":
                coin += 2;
                break;
            case "Five":
                coin += 5;
                break;
            case "Ten":
                coins += 10;
                break;
            case "Twenty":
                coins += 20;
                break;
            case "Fifty":
                coins += 50;
                break;
            default:
                break;
        }
    }
}
