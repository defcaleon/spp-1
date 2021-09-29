namespace Library.Serialization
{
    public interface ISerialization
    {
        void serialize(System.IO.Stream output, ITraceResult resultList);
    }
}
