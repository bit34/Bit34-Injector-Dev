namespace Bit34.DI.Test.Payloads
{
    public class CrossReferenceContainer
    {
        [Inject]
        public CrossReferenceClassA valueA;
        [Inject]
        public CrossReferenceClassB valueB;
    }
}
