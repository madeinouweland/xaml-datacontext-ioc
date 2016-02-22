using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContextIoC
{
    class PersonFormInteractor : PersonFormView.IViewModel
    {
        private string _name;
        private PersonInteractor _persister;
        private int _personId;

        public PersonFormInteractor(PersonInteractor persister, int personId)
        {
            _personId = personId;
            _persister = persister;
            Name = persister.FindById(_personId).Name;
        }

        public string Name { get; set; }

        public void Save()
        {
            _persister.UpdatePerson(_personId, _name);
        }
    }
}
