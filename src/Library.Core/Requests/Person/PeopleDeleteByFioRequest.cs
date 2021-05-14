namespace Library.Core.Requests.Person
{
    public class PeopleDeleteByFioRequest
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
    }
}