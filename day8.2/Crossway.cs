public class Crossway
{
    public string Name { get; set; }
    public string Leftway { get; set; }
    public string Rightway { get; set; }

    public Crossway? NavLeftway { get; set; }
    public Crossway? NavRightway { get; set; }

    public Crossway(string name, string left, string right)
    {
        Name = name;
        Leftway = left;
        Rightway = right;
    }

    public Crossway(string name, string left, string right, Crossway navLeft, Crossway navRight)
    {
        Name = name;
        Leftway = left;
        Rightway = right;
        NavLeftway = navLeft;
        NavRightway = navRight;
    }

    public Crossway(Crossway c){
        Name = c.Name;
        Leftway = c.Leftway;
        Rightway = c.Rightway;
        NavLeftway = c.NavLeftway;
        NavRightway = c.NavRightway;
    }

    public void Clone(Crossway c){
        Name = c.Name;
        Leftway = c.Leftway;
        Rightway = c.Rightway;
        NavLeftway = c.NavLeftway;
        NavRightway = c.NavRightway;
    }
}
