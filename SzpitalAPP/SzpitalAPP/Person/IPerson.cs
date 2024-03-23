namespace SzpitalAPP.Person
{
    public interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
        string SurName { get; set; }
        string Pesel { get; set; }
    }
}
