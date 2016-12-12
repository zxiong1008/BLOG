//1. MODEL of MVC

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq; //LINQ object representation of SQL query

namespace BLOG.Models
{


    //a class is a container which contains properties/attributes/methods
    public class FiveNumbersViewModel //: System.Math -> inheritance
    {
        public int[] fivenums { get; set; } //an attribute & a property
        /*  equivalent ^
            public class B{
                int[] nums;
                public getFiveNums(){
                return nums;
                }
            }
        */
        public int MinResult { get; set; }
        public int MaxResult { get; set; }
        public double AvgResult { get; set; }
        public int SumResult { get; set; }
        public int ProdResult { get; set; }

        //classes allow us to model real world object
        //classes are roots of objects
        //classes are noun - car
        //properties/attributes are the adj - car model#
        //methods are the verbs/actions - accel/decel/start/stop

        public void Calculate()
        {
            GetMin();
            GetMax();
            GetAvg();
            GetSum();
            GetProd();
        }

        private void GetMin()
        {
            //requires 'using System.Linq;'
            MinResult = fivenums.Min();
        }
        private void GetMax()
        {
            //requires 'using System.Linq;'
            MaxResult = fivenums.Max();
        }
        private void GetAvg()
        {
            //.Sum<> will be using in budgeting application
            AvgResult = fivenums.Average();
        }
        private void GetSum()
        {
            SumResult = fivenums.Sum();
        }
        private void GetProd()
        {
            ProdResult = 1;
            for (int i = 0; i < fivenums.Length; i++)
                ProdResult = ProdResult * fivenums[i];
        }
        //purple cube = method
        //rench = property
        //public void GetMin(int a, int b, int c, int d, int e)
        //{
        //    /*overload = list of same name function but different parameters
        //    overwriting = inheritance -> inherit properties
        //    using the inheritance above, we would use

        //    public override byte Min(byte a, byte b)
        //    {
        //        return byte;
        //    }*/

        //    int MinResult = Math.Min(a, Math.Min(b, Math.Min(c, Math.Min(d, e))));
        //}
        //public void GetMin(int[] x)
        //{
        //    MinResult = x[0];
        //    for (int i = 0; i < x.Length; i++)
        //        MinResult = Math.Min(MinResult, x[i]);
        //}
    }
}