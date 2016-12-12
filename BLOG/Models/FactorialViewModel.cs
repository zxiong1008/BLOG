using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq; //LINQ object representation of SQL query

namespace BLOG.Models
{
    public class FactorialViewModel
    {
        public int FactNumber { get; set; }
        public int FactResult { get; set; }

        public void CalculateFact()
        {
            GetFactorial();
        }
        private void GetFactorial()
        {
            FactResult = 1;
            while (FactNumber > 1)
            {
                FactResult = FactResult * FactNumber--; //allow the decrement in one line by using post algorithm
            }
        }

    }

}


