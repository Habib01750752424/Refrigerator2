using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace RefrigeratorAppPractice3
{
    public class Refrigerator
    {
        public double max;
        List<double> Items = new List<double>();
        List<double> Units = new List<double>();
        List<double> Weights = new List<double>();
        private double currW = 0;
        private double item = 0;
        private double unit = 0;
        private double weight = 0;
        private double remainingWeight;
        private double currentWeight;
        private double totalWeight = 0;


        public Refrigerator(double maxValue)
        {
            max = maxValue;
        }

        public bool Set(double item,double weight)
        {
            currentWeight = item * weight;
            totalWeight = totalWeight + currentWeight;
            bool isOverflow = false;
            if (totalWeight < max)
            {
                Items.Add(item);
                Units.Add(weight);
                Weights.Add(currentWeight);
            }
            else
            {
                isOverflow = true;
                totalWeight = totalWeight - currentWeight;
            }

            return isOverflow;
        }


        public double GetCurrentWeight()
        {
            return currentWeight;
        }

        public double GetWeight()
        {
            weight = 0;

            foreach (var CW in Weights)
            {
               weight = weight + CW;
            }
            return weight;
        }

        public double GetItems()
        {
            item = 0;

            foreach (var itm in Items)
            {
                item = item + itm;
            }
            return item;
        }

        public double GetUnit()
        {
            unit = 0;

            foreach (var unt in Units)
            {
                unit = unit + unt;
            }
            return unit;
        }

        public double RemainingWeight()
        {
            remainingWeight = max - GetWeight();
            return remainingWeight;
        }
    }
}
