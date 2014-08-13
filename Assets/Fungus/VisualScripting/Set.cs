using UnityEngine;
using System.Collections;

namespace Fungus.Script
{

	public class Set : FungusCommand 
	{
		public enum SetOperator
		{
			Assign,		// =
			Negate,		// !
			Add, 		// +=
			Subtract,	// -=
			Multiply,	// *=
			Divide		// /=
		}

		public FungusVariable variable;

		public SetOperator setOperator;

		public BooleanData booleanData;

		public IntegerData integerData;

		public FloatData floatData;

		public StringData stringData;
		
		public override void OnEnter()
		{
			if (variable == null)
			{
				Continue();
				return;
			}

			if (variable.GetType() == typeof(BooleanVariable))
			{
				BooleanVariable lhs = (variable as BooleanVariable);
				bool rhs = booleanData.Value;

				switch (setOperator)
				{
				default:
				case SetOperator.Assign:
					lhs.Value = rhs;
					break;
				case SetOperator.Negate:
					lhs.Value = !rhs;
					break;
				}
			}
			else if (variable.GetType() == typeof(IntegerVariable))
			{
				IntegerVariable lhs = (variable as IntegerVariable);
				int rhs = integerData.Value;

				switch (setOperator)
				{
				default:
				case SetOperator.Assign:
					lhs.Value = rhs;
					break;
				case SetOperator.Add:
					lhs.Value += rhs;
					break;
				case SetOperator.Subtract:
					lhs.Value -= rhs;
					break;
				case SetOperator.Multiply:
					lhs.Value *= rhs;
					break;
				case SetOperator.Divide:
					lhs.Value /= rhs;
					break;
				}
			}
			else if (variable.GetType() == typeof(FloatVariable))
			{
				FloatVariable lhs = (variable as FloatVariable);
				float rhs = floatData.Value;
				
				switch (setOperator)
				{
				default:
				case SetOperator.Assign:
					lhs.Value = rhs;
					break;
				case SetOperator.Add:
					lhs.Value += rhs;
					break;
				case SetOperator.Subtract:
					lhs.Value -= rhs;
					break;
				case SetOperator.Multiply:
					lhs.Value *= rhs;
					break;
				case SetOperator.Divide:
					lhs.Value /= rhs;
					break;
				}
			}
			else if (variable.GetType() == typeof(StringVariable))
			{
				StringVariable lhs = (variable as StringVariable);
				string rhs = stringData.Value;

				switch (setOperator)
				{
				default:
				case SetOperator.Assign:
					lhs.Value = rhs;
					break;
				}
			}

			Continue();
		}

		public override string GetDescription()
		{
			if (variable == null)
			{
				return "<Variable not selected>";
			}

			string description = variable.key;

			switch (setOperator)
			{
			default:
			case SetOperator.Assign:
				description += " = ";
				break;
			case SetOperator.Negate:
				description += " != ";
				break;
			case SetOperator.Add:
				description += " += ";
				break;
			case SetOperator.Subtract:
				description += " -= ";
				break;
			case SetOperator.Multiply:
				description += " *= ";
				break;
			case SetOperator.Divide:
				description += " /= ";
				break;
			}

			if (variable.GetType() == typeof(BooleanVariable))
			{
				description += booleanData.GetDescription();
			}
			else if (variable.GetType() == typeof(IntegerVariable))
			{
				description += integerData.GetDescription();
			}
			else if (variable.GetType() == typeof(FloatVariable))
			{
				description += floatData.GetDescription();
			}
			else if (variable.GetType() == typeof(StringVariable))
			{
				description += stringData.GetDescription();
			}

			return description;
		}
	}

}
