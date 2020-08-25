using System.Linq;
using csharp_examples.FlashCards;
using FsCheck;

namespace NUnitTest
{
    public class Tipos
    {
        public static Arbitrary<int> Porcentagem() =>
            Arb.Default.Int32().Generator.
                Where(x => x > 0 && x <= 100).ToArbitrary();


        
        
        
        
        
        
        
        
        
        
        
        
        
        public static Arbitrary<Cartão> Cartão() =>
            Porcentagem().Generator
                .Select(porcentagem => new Cartão(Arb.Default.String().Generator.Sample(20, 1).Single() , porcentagem))
                .ToArbitrary();
    }
}