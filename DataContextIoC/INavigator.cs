using System;
using System.Reactive.Subjects;

namespace DataContextIoC
{
    public class Data<T> where T : struct
    {
        public Data(T? oldValue, T? newValue)
        {
            Old = oldValue;
            New = newValue;
        }
        
        public Nullable<T> Old { get; }
        public Nullable<T> New { get; }
    }

    public interface INavigator
    {
        void ToPerson(int? id);
        
        IObservable<Data<int>> PersonId { get; }
    }

    public class Navigator : INavigator
    {
        class NavigationValue<T> where T : struct
        {
            public Subject<Data<T>> Subject=new Subject<Data<T>>();
            public T? CurrentValue;
        }

        private NavigationValue<int> _personId = new NavigationValue<int>();

        public IObservable<Data<int>> PersonId => _personId.Subject;

        public void ToPerson(int? id)
        {
            var old = _personId.CurrentValue;
            _personId.CurrentValue = id;
            _personId.Subject.OnNext(new Data<int>(old, _personId.CurrentValue));
        }
    }
}