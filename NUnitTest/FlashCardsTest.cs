using csharp_examples.FlashCards;
using FsCheck;
using FsCheck.NUnit;

namespace NUnitTest
{
    public class FlashCardsTest
    {
        [Property]
        public Property DeveDiminuirDificuldadeQuandoAcertarAResposta(int porcentagem)
        {
            var calculadora = new CalculadoraDeDificuldade();
            var cartão = new Cartão("qlqr pergunta", porcentagem);

            var novoCartão = calculadora.AjustaDificuldade(cartão, true);

            return (novoCartão.Porcentagem < porcentagem).ToProperty().Collect(porcentagem);
        }
        
        
        [Property]
        public Property DeveAumentarDificuldadeQuandoErrarAResposta(int porcentagem)
        {
           var calculadora = new CalculadoraDeDificuldade();
           var cartão = new Cartão("qlqr pegunta", porcentagem);

           var novoCartão = calculadora.AjustaDificuldade(cartão, false);

           return (novoCartão.Porcentagem > porcentagem).ToProperty().When(porcentagem != 0 && porcentagem < 100);
        }
        
        [Property(Arbitrary = new[] {typeof(Tipos)})]
        public Property DeveDiminuirDificuldadeQuandoAcertarAResposta2(int porcentagem)
        {
            var calculadora = new CalculadoraDeDificuldade();
            var cartão = new Cartão("qlqr pergunta", porcentagem);

            var novoCartão = calculadora.AjustaDificuldade(cartão, true);

            return (novoCartão.Porcentagem < porcentagem).ToProperty().Collect(porcentagem);
        }
        
        [Property(Arbitrary = new[] {typeof(Tipos)})]
        public Property DeveDiminuirDificuldadeQuandoAcertarAResposta3(Cartão cartão)
            {
             var calculadora = new CalculadoraDeDificuldade();

             var novoCartão = calculadora.AjustaDificuldade(cartão, true);

             return (novoCartão.Porcentagem < cartão.Porcentagem).ToProperty().Collect(cartão.Pergunta).Collect(cartão.Porcentagem);
            }
        }
}