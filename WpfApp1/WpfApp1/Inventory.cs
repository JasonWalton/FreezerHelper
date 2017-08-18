using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class Inventory
    {
        public ObservableCollection<Dish> Dishes = new ObservableCollection<Dish>();

        List<Dish> DishesByCategory(DishCategory category)
        {
            List<Dish> bakedGoods = new List<Dish>();
            List<Dish> breakfasts = new List<Dish>();
            List<Dish> dinners = new List<Dish>();
            List<Dish> snacks = new List<Dish>();
            List<Dish> all = new List<Dish>();

            all.AddRange(bakedGoods);
            all.AddRange(breakfasts);
            all.AddRange(dinners);
            all.AddRange(snacks);

            return all;
        }
        //List<Dish> DishesByAlphabetic() { }
        //List<Dish> DishesByDate() { }
        public Inventory()
        { 
            AddDishCommand = new RelayCommand(AddDish);
            Dishes.CollectionChanged += DishesOnCollectionChanged;
        }
        private void DishesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            
        }

        void AddDish(Dish dish, DateTime date = new DateTime())
        {
            if (date == DateTime.MinValue)
                dish.Date = DateTime.Now;
            Dishes.Add(dish);
        }

        void AddDish()
        {
            Dish dish = new Dish("Name", DishCategory.Dinners, DishLocation.Downstairs, 4);

            NewDish newDish = new NewDish();
            newDish.DataContext = dish;
            bool? val = newDish.ShowDialog();
            if (val.HasValue && val.Value)
                Dishes.Add(dish);
        }
        void AddDish(Dish dish)
        {
            AddDish(dish, dish.Date);
        }
        public ICommand AddDishCommand { get; }

        private class RelayCommand : ICommand
        {
            private Action<Dish, DateTime> addDish;

            public RelayCommand(Action execute) : this(execute, null) { } //(Action<Dish, DateTime> addDish)
                                                                          //{
            //    this.addDish = addDish;
            //}
            public RelayCommand(Action execute, Func<bool> canExecute)
            {
                _execute = execute;
                _canExecute = canExecute;
            }
            readonly Func<bool> _canExecute;
            readonly Action _execute;
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter) { return _canExecute == null || _canExecute(); }
            public void Execute(object parameter) { _execute(); }
            public void RaiseCanExecuteChanged() { CanExecuteChanged?.Invoke(this, EventArgs.Empty); }
        }
    }
}
