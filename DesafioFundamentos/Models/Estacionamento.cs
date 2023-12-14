using System.Text.RegularExpressions; // import

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial = 0;
        private decimal PrecoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {   // Implementadoo!!
            Console.Write("Informe a placa do veículo para estacionar: ");
            string placa = Console.ReadLine();

            if (veiculos.Contains(placa))
            {
                Console.WriteLine($"Veículo de Placa: {placa}, já está estacionado.");
                return;
            }

            if (ValidarPlaca(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine("Placa válida! Veículo estacionado com sucesso!!");
            }
            else
            {
                Console.WriteLine("A placa é inválida!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                int horas = int.Parse(Console.ReadLine());

                decimal valorTotal = (PrecoInicial + PrecoPorHora) * horas;
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo de Placa: {placa}, foi removido e o preço total foi de: R$ {valorTotal.ToString("F2")}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                int contaVeiculo = 1;
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Vaga {contaVeiculo} - Veículo de Placa: {veiculo} está estacionado!");
                    contaVeiculo++;
                }
            }
            else
            {
                Console.WriteLine("OBS, Não há veículos estacionados.");
            }
        }

        static bool ValidarPlaca(string placa)
        {
            // ATENÇÂO! --> Padrão para placa de carro (XXX9999)
            string padraoPlaca = @"^[A-Z]{3}\d{4}$";

            Regex regexPlaca = new Regex(padraoPlaca);
            return regexPlaca.IsMatch(placa);
        }

        public void Menu()
        {
            bool exibirMenu = true;
            while (exibirMenu)
            {
                Console.Clear();
                Console.WriteLine("Informe a sua opção:");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");

                switch (Console.ReadLine())
                {
                    case "1":
                        AdicionarVeiculo();
                        break;
                    case "2":
                        RemoverVeiculo();
                        break;
                    case "3":
                        ListarVeiculos();
                        break;
                    case "4":
                        exibirMenu = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadLine();
            }
        }
    }
}