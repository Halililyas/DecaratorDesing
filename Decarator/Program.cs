using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decarator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonelCar { Mike = "BMV", Model = "3.20", HirePrice = 2500 };
            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            specialOffer.Indırım = 10;
            Console.WriteLine("Concrate {0}", personelCar.HirePrice);
            Console.WriteLine("Special Offer {0}", specialOffer.HirePrice);

            Console.ReadLine();
        }
    }
    abstract class CarBase // Burda Araba Base yaptık ve içerisinde araba hakınnda özellikler var 
    {
        public abstract string Mike { get; set; }
        public abstract string Model { get; set; }
        public abstract int HirePrice { get; set; }

    }
    class PersonelCar : CarBase // Burda personeller için araba özellikleri ve carbase implamete edilerek 
    {
        public override string Mike { get; set; }
        public override string Model { get; set; }
        public override int HirePrice { get; set; }
    }
    class CommercialCar : CarBase // Bur da Ticaret Arabaları için özellikler Tanımlandı ve Car Base den implamente edildi 
    {
        public override string Mike { get; set; }
        public override string Model { get; set; }
        public override int HirePrice { get; set; }
    }
    abstract class CarDecorator : CarBase // CarDecorator  diye Bir Sınıf oluşturup Carbase implmente edildi
    {
        private CarBase _CarBase;
        protected CarDecorator(CarBase carBase)
        {
            _CarBase = carBase;
        }

    }
    class SpecialOffer : CarDecorator// ÖZel Teklif verebilmek için bir ürün için 
    {
        private readonly CarBase _carbase;
        public int Indırım { get; set; }
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carbase = carBase;
        }
        public override string Mike { get; set; }
        public override string Model { get; set; }
        public override int HirePrice
        {
            get
            {
                return _carbase.HirePrice - _carbase.HirePrice * Indırım / 100;
            }
            set
            {
            }
        }


    }
}
