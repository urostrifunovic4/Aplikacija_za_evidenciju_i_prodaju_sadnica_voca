using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class VockaVrstaBusiness
    {
        private readonly VockaVrstaRepository vockaVrstaRepository;


        public VockaVrstaBusiness()
        {
            this.vockaVrstaRepository = new VockaVrstaRepository();
        }

        public List<Vocka_Vrsta> GetAllVockaVrsta()
        {
            return this.vockaVrstaRepository.GetAllVoce();
        }


        public bool InsertVockaVrsta(Vocka_Vrsta v)
        {
            if (this.vockaVrstaRepository.InsertVoce(v) > 0)
                return true;
            else
                return false;

        }

        public bool UpdateVockaVrsta(Vocka_Vrsta v)
        {
            if (this.vockaVrstaRepository.UpdateVoce(v) > 0)
                return true;
            else
                return false;

        }

        public bool UpdateVockaVrsta2(Vocka_Vrsta v)
        {
            if (this.vockaVrstaRepository.UpdateVoce2(v) > 0)
                return true;
            else
                return false;

        }

        public bool DeleteVockaVrsta(int id)
        {
            if (this.vockaVrstaRepository.DeleteVoce(id) > 0)
                return true;
            else
                return false;

        }




    }
}
