using DesafioTecnicoFramework.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Text;

namespace DesafioTecnicoFramework.Test
{
    [TestClass]
    public class DesafioUnitTest
    {
        private Mock<IConsoleHelper> mockConsoleHelper;

        [TestInitialize]
        public void Initialize()
        {
            mockConsoleHelper = new Mock<IConsoleHelper>();
        }

        [TestMethod]
        public void Desafio_Metodo_Start()
        {
            mockConsoleHelper.SetupSequence(x => x.ReadLine()).Returns("1").Returns("S");

            Calculadora calculadora = new Calculadora(mockConsoleHelper.Object);

            calculadora.Start();
        }

        [TestMethod]
        public void Desafio_Metodo_Start_ValorDigitadoNaoNumerico()
        {
            mockConsoleHelper.SetupSequence(x => x.ReadLine()).Returns("x").Returns("10").Returns("S");

            Calculadora calculadora = new Calculadora(mockConsoleHelper.Object);

            calculadora.Start();
        }

        [TestMethod]
        public void Desafio_Metodo_Start_Exception()
        {
            mockConsoleHelper.SetupSequence(x => x.ReadLine()).Throws(new Exception("Exception teste")).Returns("10").Returns("S");

            Calculadora calculadora = new Calculadora(mockConsoleHelper.Object);

            calculadora.Start();
        }

        [TestMethod]
        public void Desafio_Teste_Resultado_Ok()
        {
            var numeros = new Numeros
            {
                Entrada = 45
            };

            var resultadoEsperado = new Numeros()
            {
                Entrada = 45,
                Divisores = new StringBuilder("1 3 5 9 15 45 "),
                Primos = new StringBuilder("3 5 ")
            };

            Calculadora calculadora = new Calculadora(mockConsoleHelper.Object);

            var retorno = calculadora.CalculaNumeros(numeros);

            Assert.AreEqual(retorno.Entrada, 45);
            Assert.AreEqual(retorno.Divisores.ToString(), resultadoEsperado.Divisores.ToString());
            Assert.AreEqual(retorno.Primos.ToString(), resultadoEsperado.Primos.ToString());
        }

        [TestMethod]
        public void Desafio_Teste_Resultado_NumeroPrimoNaoExistente()
        {
            var numeros = new Numeros
            {
                Entrada = 1
            };

            var resultadoEsperado = new Numeros()
            {
                Entrada = 1,
                Divisores = new StringBuilder("1 "),
                Primos = new StringBuilder("")
            };

            Calculadora calculadora = new Calculadora(mockConsoleHelper.Object);

            var retorno = calculadora.CalculaNumeros(numeros);

            Assert.AreEqual(retorno.Entrada, 1);
            Assert.AreEqual(retorno.Divisores.ToString(), resultadoEsperado.Divisores.ToString());
            Assert.AreEqual(retorno.Primos.ToString(), resultadoEsperado.Primos.ToString());
        }
    }
}
