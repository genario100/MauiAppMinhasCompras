using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        string _descricao;
        double _preco;
        double _quant;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao
        {
            get => _descricao;
            set
            {
                try 
                {
                 if (value == null)
                {
                    //throw new Exception("Por favor, preencha a descrição!");
                        //throw new Exception ("Por favor, preencha a descrição!");

                }
                    
                    _descricao = value;

                }
                catch (Exception)
                {
                    throw new Exception($"{_descricao}");
                }

            }
            
        }
        

        public double Preco
        {
            get => _preco;
            set
            {
                try
                {

                    if (double.IsNaN(value))
                    {
                        throw new Exception("Por favor, preencha o preço!");
                    }
                }
                catch (NullReferenceException)
                {
                    throw new Exception("Por favor, preencha o preço!");
   
                }
                    _preco = value;
            }
        }

        public double Quantidade
        {
            get => _quant;
            set
            {

                try
                { 
                if (double.IsNaN(value))
                {
                    throw new Exception("Por favor, preencha a quantidade!");
                }
            }
            catch (NullReferenceException)
            {
                throw new Exception("Por favor, preencha a quantidade!");

            }
            _quant = value;


            }
        }

        public double Total { get => Preco * Quantidade; }
        public DateTime DataCompra { get; set; }
    }
}
