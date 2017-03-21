using System;

namespace SoftimizeMaster
{
    /// <summary>
    /// The action performed on the collection.
    /// </summary>
    public enum ActionType { Add, Remove }

    /// <summary>
    /// Represents the event data to pass to subscribers when the collection has changed.
    /// </summary>
    /// <typeparam name="T"></typeparam>
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