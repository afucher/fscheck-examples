namespace csharp_examples.FlashCards
{
    public class CalculadoraDeDificuldade
    {
        public Cartão AjustaDificuldade(Cartão cartão, bool acertou)
        {
            return acertou 
                ? new Cartão(cartão.Pergunta, cartão.Porcentagem - 1) 
                : new Cartão(cartão.Pergunta,cartão.Porcentagem + 1);
        }
    }
}