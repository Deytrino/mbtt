using TestLibrary;

namespace Task_1_Tests
{
	public class Tests
	{
		[Test]
		public void NormalCircleCreation()
		{
			Assert.DoesNotThrow(() => new Circle(100));
		}

		[Test]
		public void ZeroRadiusCircleCreation()
		{
			Assert.DoesNotThrow(() => new Circle(0));
		}

		[Test]
		public void NegativeRadiusCircleCreation()
		{
			Assert.Throws<ArgumentException>(() => new Circle(-20));
		}

		[Test]
		public void ZeroRadiusCircleArea()
		{
			var circle = new Circle(0);

			var result = circle.GetArea();
			var expected = 0;

			Assert.That(result, Is.EqualTo(expected).Within(0.0000001));
		}

		[Test]
		public void PositiveRadiusCircleArea()
		{
			var radius = 1.5;
			var circle = new Circle(radius);

			var expected = radius*radius*Math.PI;
			var result = circle.GetArea();

			Assert.That(result, Is.EqualTo(expected).Within(0.0000001));
		}


		[Test]
		public void BigPositiveRadiusCircleArea()
		{
			var radius = double.MaxValue;
			var circle = new Circle(radius);

			var expected = radius*radius*Math.PI;
			var result = circle.GetArea();

			Assert.That(result, Is.EqualTo(expected).Within(0.0000001), "Wrong circle area: infinity not equals infinity o_O");
		}

		[Test]
		public void CircleAreaThroughInterface()
		{
			var radius = 42;
			IFigure figure = new Circle(radius);

			var expected = radius*radius*Math.PI;
			var result = figure.GetArea();

			Assert.That(result, Is.EqualTo(expected).Within(0.0000001));
		}



		[Test]
		public void IsNormalTriangle()
		{
			var sideA = 10;
			var sideB = 14;
			var sideC = 9;

			var result = Triangle.IsTriangle(sideA, sideB, sideC);
			var expected = true;

			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void IsTriangleZeroArea()
		{
			var sideA = 1;
			var sideB = 2;
			var sideC = 3;

			var result = Triangle.IsTriangle(sideA, sideB, sideC);
			var expected = true;

			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void IsTriangleZeroSide()
		{
			var sideA = 1;
			var sideB = 1;
			var sideC = 0;

			var result = Triangle.IsTriangle(sideA, sideB, sideC);
			var expected = true;

			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void IsTriangleZeroSides()
		{
			var sideA = 0;
			var sideB = 0;
			var sideC = 0;

			var result = Triangle.IsTriangle(sideA, sideB, sideC);
			var expected = true;

			Assert.That(result, Is.EqualTo(expected));
		}
		[Test]
		public void IsNotTriangle()
		{
			var sideA = 1;
			var sideB = 2;
			var sideC = 10;

			var result = Triangle.IsTriangle(sideA, sideB, sideC);
			var expected = false;

			Assert.That(result, Is.EqualTo(expected));
		}
		[Test]
		public void IsNotTriangleNegativeSide()
		{
			var sideA = -1;
			var sideB = 2;
			var sideC = 3;

			var result = Triangle.IsTriangle(sideA, sideB, sideC);
			var expected = false;

			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void NormalTriangleCreation()
		{
			var sideA = 10;
			var sideB = 14;
			var sideC = 9;

			Assert.DoesNotThrow(() => new Triangle(sideA, sideB, sideC));
		}

		[Test]
		public void ZeroSidesTriangleCreation()
		{
			var sideA = 0;
			var sideB = 0;
			var sideC = 0;

			Assert.DoesNotThrow(() => new Triangle(sideA, sideB, sideC));
		}

		[Test]
		public void NegativeSideTriangleCreation()
		{
			var sideA = -1;
			var sideB = 2;
			var sideC = 3;

			Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
		}


		[Test]
		public void WrongSidesTriangleCreation()
		{
			var sideA = 1;
			var sideB = 3;
			var sideC = 100;

			Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
		}

		[Test]
		public void IsRightTriangle()
		{
			var sideA = 3;
			var sideB = 4;
			var sideC = 5;
			var triangle = new Triangle(sideA, sideB, sideC);

			var result = triangle.CheckIsRightTriangle();
			var expected = true;

			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void IsNotRightTriangle()
		{
			var sideA = 10;
			var sideB = 14;
			var sideC = 9;
			var triangle = new Triangle(sideA, sideB, sideC);

			var result = triangle.CheckIsRightTriangle();
			var expected = false;

			Assert.That(result, Is.EqualTo(expected));
		}


		[Test]
		public void ZeroSidesTriangleArea()
		{
			var sideA = 0;
			var sideB = 0;
			var sideC = 0;
			var triangle = new Triangle(sideA, sideB, sideC);

			var result = triangle.GetArea();
			var expected = 0;

			Assert.That(result, Is.EqualTo(expected).Within(0.0000001));
		}

		[Test]
		public void DegenerateTriangleArea()
		{
			var sideA = 10;
			var sideB = 4;
			var sideC = 6;
			var triangle = new Triangle(sideA, sideB, sideC);

			var result = triangle.GetArea();
			var expected = 0;

			Assert.That(result, Is.EqualTo(expected).Within(0.0000001));
		}


		[Test]
		public void NormalTriangleArea()
		{
			var sideA = 10;
			var sideB = 14;
			var sideC = 9;
			var triangle = new Triangle(sideA, sideB, sideC);

			var result = triangle.GetArea();
			var expected = 44.84347778663;

			Assert.That(result, Is.EqualTo(expected).Within(0.0000001));
		}


		[Test]
		public void BigSidesTriangleArea()
		{
			var sideA = double.MaxValue;
			var sideB = double.MaxValue;
			var sideC = double.MaxValue;
			var triangle = new Triangle(sideA, sideB, sideC);

			var result = triangle.GetArea();
			var expected = double.PositiveInfinity;

			Assert.That(result, Is.EqualTo(expected).Within(0.0000001));
		}

		[Test]
		public void TriangleAreaThroughInterface()
		{
			var sideA = 3;
			var sideB = 4;
			var sideC = 5;
			IFigure figure = new Triangle(sideA, sideB, sideC);

			var result = figure.GetArea();
			var expected = 6.0;

			Assert.That(result, Is.EqualTo(expected).Within(0.0000001));
		}
	}
}