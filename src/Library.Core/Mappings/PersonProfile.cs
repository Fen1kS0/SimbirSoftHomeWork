using AutoMapper;
using Library.Core.Entities;
using Library.Core.Requests.Person;
using Library.Core.Responses.Person;

namespace Library.Core.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonAddRequest, Person>();
            
            CreateMap<PersonUpdateRequest, Person>();
            
            CreateMap<Person, PersonResponse>();
        }
    }
}