using FsCheck;
using NUnit.Framework;
using static csharp_examples.Operacoes;

namespace NUnitTest
{
    public class Tests
    {

        [Test]
        public void SomaDoisnúmeros()
        {
            Assert.AreEqual(5, Soma(2, 3));
        }

        [TestCase(5, 2, 3)]
        [TestCase(5, 8, -3)]
        public void SomaAlgunsDoisnúmeros(int esperado, int número1, int número2)
        {
            Assert.AreEqual(esperado, Soma(número1, número2));
        }

        [Test]
        public void SomaDoisnúmerosNãoImportaAOrdem()
        {
            var resultado1 = Soma(2, 8);
            var resultado2 = Soma(8, 2);
            Assert.AreEqual(resultado1,resultado2);
        }
        
        
        
        
        [FsCheck.NUnit.Property]
        public Property SomaVariosDoisnúmeros(int número1, int número2)
        {
            var resultado = Soma(número1, número2);
            return ((número1 + número2) == resultado).ToProperty();
        }

        [FsCheck.NUnit.Property]
        public Property SomaDoisnúmerosNãoDependeDaOrdemDoParâmetro(int número1, int número2)
        {
            var resultado1 = Soma(número1, número2);
            var resultado2 = Soma(número2, número1);
            return (resultado1 == resultado2).ToProperty();
        }

        [FsCheck.NUnit.Property]
        public Property SomaDoisnúmerosIguaisDeveSerIgualAoDobroDonúmero(int número)
        {
            var resultado = Soma(número, número);
            return (resultado == (número * 2)).ToProperty();
        }

        [FsCheck.NUnit.Property]
        public Property SomaDoisnúmerosQuandoUmÉZeroDeveRetornarOValorPassado(int número)
        {
            var resultado = Soma(número, 0);
            return (resultado == número).ToProperty();
        }
    }
}