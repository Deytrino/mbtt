using System;

namespace TestLibrary
{
	// Можно ещё через абстрактный класс, но в данном примере общее только поведение, не параметры сущностей
	// поэтому пусть будет интерфейс
	public interface IFigure
	{
		// Можно ещё сделать через свойство:
		// public double Area { get; }
		// но обойдёмся классическим методом

		/// <summary>
		/// Calculate the area of this figure using its parameters
		/// </summary>
		/// <returns>
		/// Area of the figure
		/// </returns>
		public double GetArea();
	}

	public class Circle : IFigure
	{
		public double Radius { get; }

		public Circle(double radius)
		{
			// Окружность с нулевым радиусом - тоже окружность, хоть и вырожденная, его разрешим
			if (radius < 0)
			{
				// Как вариант, вместо эксепшенов в конструкторах можно сделать фабричные методы,
				// возвращающие новый объект при валидных параметрах и null - при невалидных, а сами конструкторы спрятать в private
				// Но в этот раз захотелось такой вариант
				throw new ArgumentException("Radius must be a non-negative number");
			}

			Radius = radius;
		}

		public double GetArea()
		{
			return Radius*Radius*Math.PI;
		}
	}

	public class Triangle : IFigure
	{
		public double SideA { get; }
		public double SideB { get; }
		public double SideC { get; }

		public Triangle(double sideA, double sideB, double sideC)
		{
			if (!IsTriangle(sideA, sideB, sideC))
			{
				throw new ArgumentException("A triangle with such sides cannot exist");
			}

			SideA = sideA;
			SideB = sideB;
			SideC = sideC;
		}

		public double GetArea()
		{
			var p = (SideA + SideB + SideC)/2;
			return Math.Sqrt(p*(p - SideA)*(p - SideB)*(p - SideC));
		}


		/// <summary>
		/// Checking if a triangle is right-angled
		/// </summary>
		public bool CheckIsRightTriangle()
		{
			// вырожденный
			if (SideA*SideB*SideC == 0)
			{
				return false;
			}
			
			return сheckIsHypotenuse(SideA, SideB, SideC) || сheckIsHypotenuse(SideB, SideA, SideC) || сheckIsHypotenuse(SideC, SideA, SideB);
		}

		/// <summary>
		/// Checking that the side of the triangle passed by the first argument is the hypotenuse, and the other two are legs
		/// </summary>
		private bool сheckIsHypotenuse(double potentialHypotenuse, double potentialLegA, double potentialLegB)
		{
			return potentialHypotenuse*potentialHypotenuse == potentialLegA*potentialLegA + potentialLegB*potentialLegB;
		}

		/// <summary>
		/// Check the existence of a triangle with given sides
		/// </summary>
		/// <returns>
		/// True - a triangle with these sides exists,
		/// False - there is no triangle with these sides
		/// </returns>
		public static bool IsTriangle(double sideA, double sideB, double sideC)
		{
			if (sideA < 0 || sideB < 0 || sideC < 0)
			{
				return false;
			}
			return (sideA + sideB >= sideC) && (sideA + sideC >= sideA) && (sideB + sideC >= sideA);	
		}
	}
}