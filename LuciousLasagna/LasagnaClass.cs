using System;

namespace C_sharp_practice
{
    class Lasagna
    {
        public int layers;

        //Returns the total cooking time taking in the number of layers in the lasagna.
        public static int cookingTime(int layers)
        {
            int totalTime = (layers * 2) + 40;
            return totalTime; 
        }

        //Returns the remaining cooking time after taking the time that the lasagna has already been in the oven
        public static int remainingTime(int currentOvenTime, int totalTime)
        {
            int timeRemaining = totalTime - currentOvenTime;
            return timeRemaining; 
        }
    }
}