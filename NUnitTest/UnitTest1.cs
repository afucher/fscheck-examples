using FsCheck;
using NUnit.Framework;
using static csharp_examples.Operacoes;

namespace NUnitTest
{
    public class Tests
    {

        [Test]
        public void SomaDoisNumeros()
        {
            Assert.AreEqual(5, Soma(2, 3));
        }



        [TestCase(5, 2, 3)]
        [TestCase(5, 8, -3)]
        public void SomaAlgunsDoisNumeros(int esperado, int numero1, int numero2)
        {
            Assert.AreEqual(esperado, Soma(numero1, numero2));
        }

        [FsCheck.NUnit.Property]
        public Property SomaVariosDoisNumeros(int numero1, int numero2)
        {
            var resultado = Soma(numero1, numero2);
            return ((numero1 + numero2) == resultado).ToProperty();
        }

        [FsCheck.NUnit.Property]
        public Property SomaDoisNumerosN�oDependeDaOrdemDoPar�metro(int numero1, int numero2)
        {
            var resultado1 = Soma(numero1, numero2);
            var resultado2 = Soma(numero2, numero1);
            return (resultado1 == resultado2).ToProperty();
        }

        [FsCheck.NUnit.Property]
        public Property SomaDoisNumerosIguaisDeveSerIgualAoDobroDoNumero(int numero1)
        {
            var resultado1 = Soma(numero1, numero1);
            return (resultado1 == (numero1 * 2)).ToProperty();
        }

        [FsCheck.NUnit.Property]
        public Property SomaDoisNumerosQuandoUm�ZeroDeveRetornarOValorPassado(int numero1)
        {
            var resultado1 = Soma(numero1, 0);
            return (resultado1 == numero1).ToProperty();
        }
    }
}