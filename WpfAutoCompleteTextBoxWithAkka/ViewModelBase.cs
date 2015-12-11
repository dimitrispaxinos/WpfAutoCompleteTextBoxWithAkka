using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace WpfAutoCompleteTextBoxWithAkka
{
        /// <summary>
        /// Base Class for the ViewModel which includes all components, which are necessary for all possible ViewModel classes
        /// </summary>
        public abstract class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public virtual void SendPropertyChanged<T>(Expression<Func<T>> expression)
            {
                if (null != PropertyChanged)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(((MemberExpression)expression.Body).Member.Name));
                }
            }

            public virtual void SendPropertyChanged([CallerMemberName]string propertyName = "")
            {
                if (null != PropertyChanged)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
            {
                if (EqualityComparer<T>.Default.Equals(field, value)) return false;
                field = value;
                SendPropertyChanged(propertyName);
                return true;
            }
        }
    }
