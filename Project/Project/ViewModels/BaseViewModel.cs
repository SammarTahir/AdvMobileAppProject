using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Project
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // change from private to protected
        protected void OnPropertyChanged(
                [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                   new PropertyChangedEventArgs(propertyName));
        }

        // also want to implement a SetValue method
        // used by all setters in the properties
        // all follows the same pattern
        // check if no change, change the value, call on prop changed
        // want this to work for any type of property
        // have a problem. This method calls OnPropertyChanged
        // OnPropChange uses CallerMemberName to tell which prop
        // changed
        // SelectedDog in MainPageVM calls SetValue
        // then SetValue calls OnPropertyChanged
        // get SelectedDog property name to OnPropertyChanged
        // backingField is passed by value - local copy,
        // change is not persistent - change to ref
        protected void SetValue<T>(ref T backingField,
                                   T value,
                  [CallerMemberName] string propertyName = null)
        {
            // can't use == to compare generic objects
            //if (backingField == value) return;
            if (EqualityComparer<T>.Default.Equals(
                                    backingField, value)) return;
            backingField = value;
            OnPropertyChanged(propertyName);
        }
    }
}
