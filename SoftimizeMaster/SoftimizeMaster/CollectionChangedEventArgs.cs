using System;

namespace SoftimizeMaster
{
    public enum ActionType { Add, Remove }

    public class CollectionChangedEventArgs<T> : EventArgs
    {
        public ActionType Action { get; private set; }
        public T Value { get; private set; }

        public CollectionChangedEventArgs(ActionType action, T value)
        {
            Action = action;
            Value = value;
        }
    }
}