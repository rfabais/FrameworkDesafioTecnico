using DesafioTecnicoFramework.Interfaces;
using System;

namespace DesafioTecnicoFramework
{
    public class Calculadora : ICalculadora
    {
        private readonly IConsoleHelper _consoleHelper = null;

        int numeroEntrada;

        public Calculadora(IConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        public void Start()
        {
            _consoleHelper.WriteLine("-----* Desafio Técninco Framework *-----");
            _consoleHelper.WriteLine("-----* Autor: Ricardo Ferraz de Arruda Bais *-----");

            while (true)
            {
                try
                {
                    while (true)
                    {
                        _consoleHelper.WriteLine("Digite um número:");

                        var entrada = _consoleHelper.ReadLine();

                        _consoleHelper.Write();

                        var entradaVerificada = VerificaEntradaNumerica(entrada, out numeroEntrada);

                        if (entradaVerificada)
                        {
                            var numeros = new Numeros
                            {
                                Entrada = numeroEntrada
                            };

                            numeros = CalculaNumeros(numeros);

                            PrintaResultado(numeros);
                            break;
                        }

                        _consoleHelper.WriteLine("Valor digitado não é um número inteiro, tente novamente.");
                    }

                    _consoleHelper.WriteLine("Pressione uma tecla para repetir ou 'S' para sair");

                    var continuacao = VerificaContinuacao();

                    if (continuacao)
                    {
                        _consoleHelper.WriteLine("-----* Obrigado, até logo! :) *-----");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    _consoleHelper.WriteLine($"Erro {ex.Message}");
                }
            }

            _consoleHelper.ReadKey();
        }

        private bool VerificaContinuacao()
        {
            var continuacao = _consoleHelper.ReadLine();

            if (continuacao == "S")
                return true;

            return false;
        }

        public Numeros CalculaNumeros(Numeros numeros)
        {
            for (int i = 1; i <= numeros.Entrada; i++)
            {
                int contadorNumeroPrimo = 0;

                if (numeros.Entrada % i == 0)
                {
                    numeros.Divisores.Append($"{i} ");

                    for (int j = 2; j <= i; j++)
                    {
                        if (i % j == 0 && i % i == 0)
                        {
                            contadorNumeroPrimo++;
                        }
                    }

                    if (contadorNumeroPrimo == 1)
                    {
                        numeros.Primos.Append($"{i} ");
                    }
                }
            }

            return numeros;
        }

        private void PrintaResultado(Numeros numeros)
        {
            _consoleHelper.WriteLine($"Numero de entrada: {numeros.Entrada}");

            _consoleHelper.WriteLine($"Números divisores: {numeros.Divisores}");

            _consoleHelper.WriteLine($"Divisores Primos: {numeros.Primos}");

            _consoleHelper.Write();
        }

        private bool VerificaEntradaNumerica(string entrada, out int numeroEntrada)
        {
            return int.TryParse(entrada, out numeroEntrada);
        }
    }
}
