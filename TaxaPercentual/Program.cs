namespace F360
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Digite o valor da taxa\n>");
            double taxValue = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine("Digite o valor da venda\n>");
            double saleValue = Convert.ToDouble(Console.ReadLine());

            var taxa = new Tax(taxValue, saleValue);
            Console.WriteLine("O percentual da taxa sobre a venda é de: " + taxa.ShowPercentual() + "%");
        }
    }

    class Tax
    {
        public Tax(double taxValue, double saleValue)
        {
            try
            {
                this._saleValue = saleValue;
                this._taxValue = taxValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private double _taxValue;

        private double _saleValue;

        public void SetTaxValue(double taxValue)
        {
            this._saleValue = taxValue;
        }

        public double GetTaxValue()
        {
            return this._taxValue;
        }

        public void SetSaleValue(double saleValue)
        {
            this._saleValue = saleValue;
        }

        public double GetSaleValue()
        {
            return this._saleValue;
        }

        public double ShowPercentual()
        {
            var percentual = (this._taxValue * 100) / this._saleValue;
            return percentual;
        }
    }
}

