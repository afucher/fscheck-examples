namespace csharp_examples.FlashCards
{
    public class Cartão
    {
        public int Porcentagem { get; }
        public string Pergunta { get; }

        public Cartão(string pergunta, int porcentagem)
        {
            Pergunta = pergunta;
            Porcentagem = porcentagem;
        }
    }
    
}