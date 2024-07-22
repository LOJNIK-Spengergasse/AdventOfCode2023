public class Crossway{
    public string name;
    public string leftway;
    public string rightway;

    public Crossway navLeftway;

    public Crossway navRightway;

    public Crossway(string name, string left, string right){
        this.name=name;
        this.leftway=left;
        this.rightway=right;
    }

    public void setNavLeft(Crossway left){
        this.navLeftway=left;
    }

        public void setNavRight(Crossway right){
        this.navRightway=right;
    }
}