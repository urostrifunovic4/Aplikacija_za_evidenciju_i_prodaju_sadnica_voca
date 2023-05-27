using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UkupnoBusiness
    {
        private readonly UkupnoRepository ukupnoRepository;

        public UkupnoBusiness()
        {
            this.ukupnoRepository = new UkupnoRepository();
        }

        public List<Ukupno> GetAll()
        {
            return this.ukupnoRepository.GetAll();
        }

        public bool Update(Ukupno u)
        {
            if (this.ukupnoRepository.Update(u) > 0)
                return true;
            else
                return false;

        }



    }
}
