using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement
{
    class Car
    {
        public int id;
        private string brand;
        private int price;
        private string about;

        public Car( string brand, int price, string about)
        {
            
            this.brand = brand;
            this.price = price;
            this.about = about;
            
        }

        public Car(List<Car> samochody, string brand, int price, string about)
        {
            if(samochody.Count ==0)
            {
                this.id = samochody.Count + 1;
            }
            else
            {
                this.id = samochody.Last().GetId() + 1;
            }
            this.brand = brand;
            this.price = price;
            this.about = about;

        }
        

        public string GetBrand()
        {
            return brand;
        }

        public int GetPrice()
        {
            return price;
        }

        public string GetAbout()
        {
            return about;
        }

        public int GetId()
        {
            return id;
        }

        public void SetBrand(string brand)
        {
            this.brand = brand;
        }

        public void SetPrice(int money)
        {
            this.price = money;
        }

        public void SetAbout(string info)
        {
            this.about = info;
        }
    }
}
