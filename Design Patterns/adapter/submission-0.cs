public class SquareHole {
    private double sideLength;

    public SquareHole(double sideLength) {
        this.sideLength = sideLength;
    }

    public bool canFit(Square square) {
        return this.sideLength >= square.getSideLength();
    }
}

public class Square {
    private double sideLength;

    public Square() {}

    public Square(double sideLength) {
        this.sideLength = sideLength;
    }

    public virtual double getSideLength() {
        return this.sideLength;
    }
}

public class Circle {
    private double radius;

    public Circle(double radius) {
        this.radius = radius;
    }

    public double getRadius() {
        return this.radius;
    }
}

public class CircleToSquareAdapter : Square {
    private Circle circle;

    public CircleToSquareAdapter(Circle circle) {
      this.circle = circle;
    }

    public override double getSideLength() {
      return 2 * this.circle.getRadius();
    }
}
