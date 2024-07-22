List<char> chars = ['J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'];
List<Bid> bidL = new List<Bid>();
 try
         {
             using (StreamReader sr = new StreamReader("dataPart2.txt"))
             {
                 string line;
                 // Filling up Data
                 while ((line = sr.ReadLine()) != null)
                 {
                     string[] lineAttributes = line.Split(' ');
                     bidL.Add(new Bid(lineAttributes[0], Int32.Parse(lineAttributes[1])));
                 }
             }
         }
         catch (Exception e){
             // Let the user know what went wrong.
             Console.WriteLine("The file could not be read:");
             Console.WriteLine(e.Message);
         }

//highCards 1
//onePairs 2
//twoPairs 3
//threeKinds 4
//fullHouses 5
//fourKinds 6
//fiveKinds 7
foreach(Bid b in bidL){
    int jOccurance=0;
    foreach(char c in chars){
        int occurance=StringUtils.CountOccurancesOf(b.getHand(), c);
        if(c=='J'){
            jOccurance=occurance;
        }
        else{
        if(b.getTyp() < 5&&(occurance==2||occurance==3)){
            foreach(char cs in chars){
                int occuranceSecondary=StringUtils.CountOccurancesOf(b.getHand(), cs);
                if(jOccurance==0&&cs!=c&&occurance==2&&occuranceSecondary==2) {
                    b.setTyp(3);
                    continue;
                    }
                else if(cs!=c&&((occurance==2&&(occuranceSecondary+jOccurance)==3) || ((occurance+jOccurance)==3&&occuranceSecondary==2))) {
                    b.setTyp(5); 
                    continue;
                    }
            }
        }
        if(occurance+jOccurance==2)occurance=2;
        else if(occurance+jOccurance==3)occurance=4;
        else if(occurance+jOccurance==4)occurance=6;
        else if(occurance+jOccurance==5)occurance=7;
        if(b.getTyp() < occurance)b.setTyp(occurance);
        }
    }
    string hexadecimalHand=b.getHand();
    hexadecimalHand=hexadecimalHand.Replace('J','1');
    hexadecimalHand=hexadecimalHand.Replace('A','E');
    hexadecimalHand=hexadecimalHand.Replace('T','A');
    hexadecimalHand=hexadecimalHand.Replace('J','B');
    hexadecimalHand=hexadecimalHand.Replace('Q','C');
    hexadecimalHand=hexadecimalHand.Replace('K','D');
    b.setOrder(int.Parse(hexadecimalHand, System.Globalization.NumberStyles.HexNumber));
}

 bidL=bidL.OrderBy(bidL => bidL.orderNr).OrderBy(b => b.typ).ToList();

  foreach(Bid b in bidL){
      b.printBid();
  }
int erg=0;
int i=0;
foreach(Bid b in bidL){
    i++;
    erg+=b.getBet()*i;
}
Console.WriteLine(erg);