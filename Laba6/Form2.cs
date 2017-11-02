using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba6
{
	public partial class Form2 : Form
	{
		// Постоянно обновляемые объекты первой и второй дроби на основе значений в текстбоксах
		Fraction f1;
		Fraction f2;
		Fraction answ;

		public Form2()
		{
			InitializeComponent();
			f1 = new Fraction();
			f2 = new Fraction();
			answ = new Fraction();
		}

		enum UpdateFractionsParam { FIRST, SECOND, BOTH};
		private void updateFractions(UpdateFractionsParam param)
		{
			errNotification.Visible = false;
			try
			{
				if (param == UpdateFractionsParam.FIRST || param == UpdateFractionsParam.BOTH) {
					int f1n = System.Convert.ToInt32(num1.Text);
					int f1d = System.Convert.ToInt32(denum1.Text);
					f1.setFraction(f1n, f1d);
				}
				if (param == UpdateFractionsParam.SECOND || param == UpdateFractionsParam.BOTH) {
					int f2n = System.Convert.ToInt32(num2.Text);
					int f2d = System.Convert.ToInt32(denum2.Text);
					f2.setFraction(f2n, f2d);
				}
			} catch (System.FormatException)
			{
				errNotification.Visible = true;
				throw;
			}
		}

		private void updateAnsw()
		{
			numAnsw.Text = System.Convert.ToString(answ.getNumerator());
			denumAnsw.Text = System.Convert.ToString(answ.getDenominator());
		}

		private void ButtonPlus_Click(object sender, EventArgs e)
		{
			try	{
				updateFractions(UpdateFractionsParam.BOTH);
			} catch (FormatException) {
				numAnsw.Clear();
				denumAnsw.Clear();
				return;
			}
			answ = f1 + f2;
			updateAnsw();
		}

		private void buttonSubstract_Click(object sender, EventArgs e)
		{
			try
			{
				updateFractions(UpdateFractionsParam.BOTH);
			}
			catch (FormatException)
			{
				numAnsw.Clear();
				denumAnsw.Clear();
				return;
			}
			answ = f1 - f2;
			updateAnsw();
		}

		private void buttonMultiply_Click(object sender, EventArgs e)
		{
			try
			{
				updateFractions(UpdateFractionsParam.BOTH);
			}
			catch (FormatException)
			{
				numAnsw.Clear();
				denumAnsw.Clear();
				return;
			}
			answ = f1 * f2;
			updateAnsw();
		}

		private void buttonDivide_Click(object sender, EventArgs e)
		{
			try
			{
				updateFractions(UpdateFractionsParam.BOTH);
			}
			catch (FormatException)
			{
				numAnsw.Clear();
				denumAnsw.Clear();
				return;
			}
			answ = f1 / f2;
			updateAnsw();
		}

		private void comboBoxLogic_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selected = comboBoxLogic.SelectedIndex;
			bool res = false;

			try
			{
				updateFractions(UpdateFractionsParam.BOTH);
			}
			catch (FormatException)
			{
				numAnsw.Clear();
				denumAnsw.Clear();
				return;
			}

			switch (selected)
			{
				case 0:
					{
						res = f1 < f2;
						break;
					}
				case 1:
					{
						res = f1 > f2;
						break;
					}
				case 2:
					{
						res = f1 <= f2;
						break;
					}
				case 3:
					{
						res = f1 >= f2;
						break;
					}
				case 4:
					{
						res = f1 == f2;
						break;
					}
				case 5:
					{
						res = f1 != f2;
						break;
					}
			}

			if (res)
			{
				logicRes.Text = "true";
			} else
			{
				logicRes.Text = "false";
			}
		}

	}
}
