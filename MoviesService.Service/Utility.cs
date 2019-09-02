using System;
using System.Collections.Generic;

namespace MoviesService.Service
{
    //Any utility function required of the project
    public static class Utility
    {        /// <summary>
        /// Determines whether a list is not null and contains any elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>True if the list is not null and contains at least one element, False if the list is null or there are no elements</returns>
        public static bool HasAny<T>(this List<T> list)
        {
            return list != null && list.Count > 0;
        }
        /// <summary>
        /// Rounds ratings to the nearest .5 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static double RoundToNearest(double d)
        {
            
            var floor = Math.Floor(d);
            var b = d - floor;
            if (b <= 0.249)
                d = floor;
            else if (b >= 0.25 && b <= 0.749)
                d = floor + 0.5;
            else
                d = floor + 1;

            return d;

        }
    }
}
