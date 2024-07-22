public static class StringUtils{
    public static int CountOccurancesOf(string s, char c){
        return s.Split(c).Length-1;
    }
}