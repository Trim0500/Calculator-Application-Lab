using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_Lab.Classes
{
    public class MathService
    {
        public static double calcOperation(double lN, double cN, MainWindow.SelectedOperator? SO)
        {
            double re = 0;

            switch(SO)
            {
                case MainWindow.SelectedOperator.Add:
                    re = lN + cN;
                    break;
                case MainWindow.SelectedOperator.Subtract:
                    re = lN - cN;
                    break;
                case MainWindow.SelectedOperator.Multiply:
                    re = lN * cN;
                    break;
                case MainWindow.SelectedOperator.Divide:
                    re = lN / cN;
                    break;
                default:
                    break;
            }
            return re;
        }
    }
}
