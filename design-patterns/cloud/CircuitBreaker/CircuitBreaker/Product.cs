using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CircuitBreaker
{
    public class Product
    {
        private string name;
        private decimal unitPrice;
        private Guid id;


        public Guid Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (this.id != value)
                {
                    this.id = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name != value)
                {
                    this.name = value;
                }
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return this.unitPrice;
            }

            set
            {
                if (this.unitPrice != value)
                {
                    this.unitPrice = value;
                }
            }
        }
    }
}