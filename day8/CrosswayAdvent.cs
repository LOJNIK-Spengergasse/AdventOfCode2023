public class CrosswayAdvent
{
    public string Name { get; set; }
    public string Leftway { get; set; }
    public string Rightway { get; set; }

    public CrosswayAdvent? NavLeftway { get; set; }
    public CrosswayAdvent? NavRightway { get; set; }

    public CrosswayAdvent(string name, string left, string right)
    {
        Name = name;
        Leftway = left;
        Rightway = right;
    }
}
