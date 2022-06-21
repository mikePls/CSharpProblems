using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns
{
    // Demonstrates a custom implementation of Iterator by using a Month class, represented
    //by days
    internal class CustomIterator
    {
        static void Main(string[] args)
        {
            var monthCollection = new DaysCollection();
            foreach (var month in monthCollection)
            {
                Console.WriteLine($"{month.Date}, days: {month.Days}");
            }
        }
    }

    class Iterator { }

    class Month 
    {
        public string Date { get; set; }
        public int Days { get; set; }
        
    }

    class DaysEnumerator : IEnumerator<Month>
    {
        private int year = 1;
        private int month = 0;

        private int yearLimit = 5; // represents the number of years this enumerator will iterate through

        //Generic method returns a Month object with assigned Date & Days attributes
        public Month Current => new Month()
        {
            Date = $"Year: {year.ToString()}, month: {month}",
            Days = DateTime.DaysInMonth(year, month)

        };

        //Non-generic method returns the generic one
        object IEnumerator.Current => Current;

        public void Dispose()
        {
            return;
        }

        // Increments this.month attribute. If month > 12, then resets to 1, and increments year attribute by one
        public bool MoveNext()
        {
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            return year < yearLimit;
        }

        public void Reset()
        {
            month = 1;
            year = 0;
        }
    }

    class DaysCollection : IEnumerable<Month>
    {
        public IEnumerator<Month> GetEnumerator()
        {
            return new DaysEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
