using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab_5
{
    internal class Program
    {
        static double calc_fun(double argument)
        {
            double result_fun = 2 * Math.Pow(argument, 5) - 2 * Math.Pow(argument, 4) - 4 * Math.Pow(argument, 3) + 2 * argument + 1;
            return result_fun;
        }


        static double calc_derivative(double argument) 
        {
            double result_fun = 10 * Math.Pow(argument, 4) - 8 * Math.Pow(argument, 3) - 12 * Math.Pow(argument, 2) + 2;
            return result_fun;
        }

        static void bisector_method(double a, double b, double eps) 
        {
            double next_x;
            int counter_i = 0;
            do
            {
                counter_i++;
                next_x = (a + b) / 2;
                if (calc_fun(next_x) * calc_fun(a) > 0)
                    a = next_x;
                else
                    b = next_x;
            } while (Math.Abs(b - a) > eps);
            Console.WriteLine($"bisector_method: {next_x}, Cout_iter: {counter_i}");
        }

        static void chord_method(double a, double b, double eps) 
        {
            int counter_i = 0;

            double next_a;
            do
            {
                counter_i++;
                next_a = a - ((calc_fun(a)) * (b - a) / (calc_fun(b) - calc_fun(a)));
                a = next_a;
            } while (Math.Abs(calc_fun(next_a)) > eps);
            Console.WriteLine($"Chord_method: {next_a}, Cout_iter: {counter_i}");
        }

        static void newtons_method(double a, double b, double eps)
        {
            int counter_i = 0;
            double x = b;
            do
            {
                counter_i++;
                x = x - (calc_fun(x) / calc_derivative(x));
            } while (Math.Abs(calc_fun(x)) > eps);
            Console.WriteLine($"Newton`s_method: {x}, Cout_iter: {counter_i}");
        }

        static void PrintSep()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
            
        }

        static void Main(string[] args)
        {
            PrintSep();
            Console.WriteLine("\tЛабораторна робота #5");
            Console.WriteLine("Виконав студент групи IC-31 Коваль Богдан");
            PrintSep();
            double eps = Math.Pow(10, -8);

            Console.WriteLine($"Промiжок [-1; 0], Точнiчнiсть: {eps}");
            
            bisector_method(-1, 0, eps);
            chord_method(-1, 0, eps);
            newtons_method(-1, 0, eps);
            PrintSep();


            Console.WriteLine($"Промiжок [0; 1], Точнiчнiсть: {eps}");
            bisector_method(0, 1, eps);
            chord_method(0, 1, eps);
            newtons_method(0, 1, eps);
            PrintSep();

            Console.WriteLine($"Промiжок [1; 2], Точнiчнiсть: {eps}");
            bisector_method(1, 2, eps);
            chord_method(1, 2, eps);
            newtons_method(1, 2, eps);
            PrintSep();
        }
    }
}
