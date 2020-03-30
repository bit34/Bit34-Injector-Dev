namespace Com.Bit34Games.DI.Test.Containers
{
    public class CrossReferenceContainer
    {
        [Inject] public CrossReferenceClassA valueA;
        [Inject] public CrossReferenceClassB valueB;
    }
}
