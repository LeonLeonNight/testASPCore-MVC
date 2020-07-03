using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testCore.ViewModels
{
    public class CreateSkiCardViewModel
    {
        public string CardHolderPhoneNumber {get;set;}
        public string CardHolderFirstName { get;set;}
        public string CardHolderLastName { get;set;}
        public DateTime CardHolderBirthDate { get;set;}
    }
}
