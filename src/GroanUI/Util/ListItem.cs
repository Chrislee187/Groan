namespace GroanUI.Util
{
    public class ListItem<TId, TValue>
    {
        public TId ID { get; }
        public TValue Value { get; }

        public ListItem(TId id, TValue value)
        {
            ID = id;
            Value = value;
        }
    }
}