using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public enum DishCategory
    {
        BakedGoods,
        Breakfast,
        Dinners,
        Snacks
    }

    public enum DishLocation
    {
        Upstairs,
        Downstairs
    }

    public enum DishRating
    {
        Unknown,
        ThumbsUp,
        ThumbsDown
    }
    public class Dish
    {
        private string _name;
        private DateTime _date;
        private DishCategory _category;
        private DishLocation _location;
        private int _servings;
        private DishRating _rating;

        public string Name { get { return _name; } set { _name = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public DishCategory Category { get { return _category; } set { _category = value; }}
        public DishRating Location { get { return _rating; } set { _rating = value; } }
        public int Servings { get { return _servings; } set { _servings = value; } }
        public DishRating Rating { get { return _rating; } set { _rating = value; } }
        public string DisplayString
        {
            get
            {
                return _name + " Serves: " + _servings.ToString() + " " + _date.ToString("M/d/yy");
            }
        }

        public Dish(string name, DishCategory category, DishLocation location, int servings)
        {
            _name = name;
            _category = category;
            _location = location;
            _servings = servings;
        }

    }
}
