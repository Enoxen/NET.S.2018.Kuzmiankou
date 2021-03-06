﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root
{
    public class RootFinder
    {
        public static double FindNthRoot(double number, int rootDegree, double precision)
        {
            if(precision <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(precision));
            }
            
            if(number < 0 && rootDegree % 2 == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number) + " " + nameof(rootDegree));
            }

            double x0 = new Random().Next(0,9);

            double delX = int.MaxValue;

            double xK = 0.0;

            while (delX > precision)
            {
                xK = ((rootDegree - 1.0) * x0 +
                number / Math.Pow(x0, rootDegree - 1)) /rootDegree;
                delX = Math.Abs(xK - x0);
                x0 = xK;
            }

            return xK;
        }
    }
}
