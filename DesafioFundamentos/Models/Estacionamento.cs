using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa;
            do{
                MensagemPlacaValida();
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                placa =  Console.ReadLine( );
            }while(!ValidarPlacaVeiculo(placa));
            veiculos.Add(placa);
        }

        public bool ValidarPlacaVeiculo(string placa){

            // Defina o padrão da expressão regular
            string pattern = @"^[A-Za-z]{3}-\d{4}$";

            // Crie um objeto Regex com o padrão
            Regex regex = new Regex(pattern);

            // Use o método IsMatch para verificar se a string atende ao formato
            if (regex.IsMatch(placa)  && placa.Length == 8)
            {
                return true;
            }

            MensagemPlacaValida();
            return false;
        }

        public void MensagemPlacaValida(){
            Console.WriteLine("\nDigite uma placa valida!"
                +"\n->Uma placa valida deve seguir o seguinte formato:"
                +"\nIniciar com 3 letras;"
                +"\nSeguido por um - (traço);"
                +"\nTerminar com 4 dígitos numéricos;"
                +"\nEx: ABC-1234 "
                );
        }

        public void RemoverVeiculo()
        {
            string placa;
            do{
                Console.WriteLine("Digite a placa do veículo para remover:");
                placa =  Console.ReadLine( );
            }while(!ValidarPlacaVeiculo(placa));
            
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");



                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas; 


                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach ( string veiculo in veiculos){
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
