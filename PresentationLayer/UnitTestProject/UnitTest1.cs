using BusinessLayer;
using DataAccessLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private readonly VockaBusiness vockaBusiness;

        public UnitTest1()
        {
            this.vockaBusiness = new VockaBusiness();
        }

        [TestMethod]

        public void isVockaInserted()
        {
            Vocka v = new Vocka();
            v.naziv = "Proba";
            var rez = vockaBusiness.InsertVockaVrsta(v);
            Assert.IsTrue(rez);
        }


        [TestMethod]
        public void isVockaChanged()
        {
            int id = 0;
            foreach(var item in vockaBusiness.GetAllVocka())
            {
                if (item.naziv == "Proba")
                {
                    id = item.id;
                    break;
                }
            }

            Vocka v = new Vocka();
            v.id = id;
            v.naziv = "Promena";

            var rez = vockaBusiness.UpdateVockaVrsta(v);
            Assert.IsTrue(rez);


        }


        [TestMethod]

        public void isVockaRemoved()
        {
            int id = 0;
            foreach(var item in vockaBusiness.GetAllVocka())
            {
                if (item.naziv == "Promena")
                {
                    id = item.id;
                    break;
                }
            }

            Vocka v = new Vocka();
            v.id = id;
            v.naziv = "Promena";

            var rez = vockaBusiness.UpdateVockaVrsta(v);
            Assert.IsTrue(rez);
        }



    }
}
