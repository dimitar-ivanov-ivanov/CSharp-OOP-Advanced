using System.Collections.Generic;

public interface ICoffeMachine
{
    int Coins { get; }

    void BuyCoffee(string size, string type);

    void InsertCoin(string coin);

	IEnumerable<CoffeeType> CoffeesSold { get; }
}
