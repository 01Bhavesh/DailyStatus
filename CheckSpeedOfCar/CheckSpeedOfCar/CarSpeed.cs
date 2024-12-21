using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSpeedOfCar
{
    public class CarSpeed
    {
        public int speedLimit;
        public int speedCar;
        public CarSpeed(int spl, int spc)
        {
            speedLimit = spl;
            speedCar = spc;
        }
        public string CheckSpeed()
        {
            if (speedCar < speedLimit)
            {
                return "Ok";
            }

                if ((speedCar - speedLimit)/5 > 12)
                {
                    return "License Suspended";
                }
                else {
                    return "demerit points are " + (speedCar - speedLimit) / 5;
                }
            
        }

    }
}
