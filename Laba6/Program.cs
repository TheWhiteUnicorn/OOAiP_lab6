using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba6
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}

	class Fraction
	{
		private int numerator = 1; // числитель
		private int denominator = 1; // знаменатель

		private static int NOD(int a, int b) {
			a = a < 0 ? -a : a;
			b = b < 0 ? -b : b;
			while (a != 0 && b != 0)
				if (a >= b)
					a %= b;
				else
					b %= a;
			return a | b;
		}
		private static int NOK(int a, int b) {
			return a * b / NOD(a, b);
		}

		// Пустой конструктор
		public Fraction() { }
		// Конструктор с параметрами
		public Fraction(int num, int den)
		{
			if (den == 0 || num == 0) throw new System.FormatException();
			numerator = num;
			denominator = den;
		}
		// Конструктор копирования
		public Fraction(Fraction f)
		{
			numerator = f.numerator;
			denominator = f.denominator;
		}
		// Задать числитель и знаменатель
		public void setFraction(int num, int den)
		{
			if (den == 0 || num == 0) throw new FormatException();
			numerator = num;
			denominator = den;
		}

		public int getNumerator() { return numerator; }
		public int getDenominator() { return denominator; }
		/*// Вывод на консоль
		public void showFraction() const;*/

		// Сократить дробь
		public void reduce()
		{
			int nod = NOD(numerator, denominator);
			numerator /= nod;
			denominator /= nod;
		}

		// Перегрузка арифметических операторов
		public static Fraction operator + (Fraction f1, Fraction f2)
		{
			f1.reduce();
			f2.reduce();

			int nok = NOK(f1.denominator, f2.denominator);

			f1.numerator *= (nok / f1.denominator);
			f2.numerator *= (nok / f2.denominator);

			f1.denominator = nok;
			f2.denominator = nok;

			int tmpNum = f1.numerator + f2.numerator;
			int tmpDen = nok;

			f1.reduce();
			f2.reduce();

			return new Fraction(tmpNum, tmpDen);
		}

		public static Fraction operator - (Fraction f1, Fraction f2)
		{
			f2.numerator *= -1;
			return f1 + f2;
		}
		public static Fraction operator * (Fraction f1, Fraction f2)
		{
			return new Fraction(f1.numerator * f2.numerator, f1.denominator * f2.denominator);
		}
		public static Fraction operator / (Fraction f1, Fraction f2)
		{
			return new Fraction(f1.numerator * f2.denominator, f1.denominator * f2.numerator);
		}

		// Перегрузка операторов сравнения
		public static bool operator < (Fraction f1, Fraction f2)
		{
			return (double)f1.numerator / (double)f1.denominator < (double)f2.numerator / (double)f2.denominator;
		}
		public static bool operator >(Fraction f1, Fraction f2)
		{
			return (double)f1.numerator / (double)f1.denominator > (double)f2.numerator / (double)f2.denominator;
		}
		public static bool operator <=(Fraction f1, Fraction f2)
		{
			return (double)f1.numerator / (double)f1.denominator <= (double)f2.numerator / (double)f2.denominator;
		}
		public static bool operator >=(Fraction f1, Fraction f2)
		{
			return (double)f1.numerator / (double)f1.denominator >= (double)f2.numerator / (double)f2.denominator;
		}
		public static bool operator ==(Fraction f1, Fraction f2)
		{
			return (double)f1.numerator / (double)f1.denominator == (double)f2.numerator / (double)f2.denominator;
		}
		public static bool operator !=(Fraction f1, Fraction f2)
		{
			return (double)f1.numerator / (double)f1.denominator != (double)f2.numerator / (double)f2.denominator;
		}
	}
}
