namespace API.Juros.MockSetup
{
    public abstract class BaseMockSetup
    {
        public bool Mocked { get; set; }
    }

    public class TaxaJurosMockSetup : BaseMockSetup { }
    
}
