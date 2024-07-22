public class Bid{
    public string hand;
    public int bet;

    public int orderNr;

    public int typ;

    public Bid(string hand, int bet){
        this.hand=hand;
        this.bet=bet;
        setOrder(0);
        setTyp(0);
    }

    public void printBid(){
        Console.WriteLine($"{hand}; {bet}; {typ}; {orderNr}");
    }

    public void setOrder(int orderNr){
        this.orderNr = orderNr;
    }

    public void setTyp(int typ){
        this.typ=typ;
    }

    public int getTyp(){
        return typ;
    }

    
    public string getHand(){
        return hand;
    }

        public int getBet(){
        return bet;
    }
}