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
        /// <param name="averageRating"></param>
        /// <returns></returns>
        public static double RoundToNearest(double averageRating)
        {            
            var floor = Math.Floor(averageRating);
            var decimalValue = averageRating - floor;
            if (decimalValue <= 0.249)
                averageRating = floor;
            else if (decimalValue >= 0.25 && decimalValue <= 0.749)
                averageRating = floor + 0.5;
            else
                averageRating = floor + 1;

            return averageRating;

        }
    }
}
