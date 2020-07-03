using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace testCore.ViewModels
{
    public class CreateSkiCardViewModel
    {
        [DisplayName("Phone Number")]
        public string CardHolderPhoneNumber {get;set;}
        [DisplayName("First Name")]
        public string CardHolderFirstName { get;set;}
        [DisplayName("Last Name")]
        public string CardHolderLastName { get;set;}
        [DisplayName("Birth Date")]
        public DateTime CardHolderBirthDate { get;set;}
    }
}
