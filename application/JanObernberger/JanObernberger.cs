namespace JanObernberger;

public class JanObernberger
{

    public List<string> Tools {get; private set;}
    public List<string> BackEnd {get; private set;}
    public List<string> FrontEnd {get; private set;}
    public List<string> ProgrammingLangs {get; private set;}
    public List<string> Languages { get; private set; }
    public bool IsHired {get; private set; }

    public JanObernberger(){
        Tools = ["Docker", "Linux", "VSCode", "IntelliJ", "Git", "ZSH", "Pandoc", "Mermaid", "C4", "Inkscape"];
        BackEnd = ["Rails", "REST", "GraphQL", "Swagger", "MQTT", "NGINX"];
        FrontEnd = ["HTML", "CSS", "JS", "JavaFX", "Hugo"];
        ProgrammingLangs = ["Java", "Go", "C", "C++", "C#", "Rails", "OCaml", "LaTeX", "SQL", "Bash"];
        Languages = ["Deutsch", "Englisch"];
        IsHired = false;
    }
    public bool Hire(string company, string email, string message, int eurosPerMonth){
        if (CorrespondsToMyInterests(company) && IsNice(message) && IsAppropriate(eurosPerMonth)) {
            acceptOffer(email);
            IsHired = true;
        }
        return IsHired;
    }

    private void acceptOffer(string email)
    {
        throw new NotImplementedException();
    }

    private bool IsAppropriate(int eurosPerMonth)
    {
        throw new NotImplementedException();
    }

    private bool IsNice(string message)
    {
        throw new NotImplementedException();
    }

    private bool CorrespondsToMyInterests(string company)
    {
        throw new NotImplementedException();
    }
}
