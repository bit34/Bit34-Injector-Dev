namespace Bit34.DI.Test.Containers
{
    public class CrossReferenceContainer
    {
        [Inject] public CrossReferenceClassA valueA;
        [Inject] public CrossReferenceClassB valueB;
    }
}
