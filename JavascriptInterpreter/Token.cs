namespace JavascriptInterpreter;
public class Token
{
    public Type MyTipe { get; }
    public string Input { get; }

    public Token(Type myTipe, string input)
    {
        MyTipe = myTipe;
        Input = input;
    }





}


public enum Type
{
    WhiteSpace,
    LineScape,
    NotMapped,
    Sign,
    Guid,
    
    LeftParentesis,
    RightParentesis,

}
