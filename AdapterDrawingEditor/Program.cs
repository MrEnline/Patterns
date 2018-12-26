using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDrawingEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape line = new Line();
            DrawingEditor drawingEditor = new DrawingEditor(line);
            drawingEditor.GetExtent();
            drawingEditor.Shape = new TextShape();
            drawingEditor.GetExtent();

            Console.ReadKey();
        }
    }

    class  DrawingEditor
    {
        public Shape Shape;

        public DrawingEditor(Shape shape)
        {
            Shape = shape;
        }

        public void GetExtent()
        {
            Console.WriteLine("Размер объекта {0}", Shape.BoundlingBox());
        }
    }

    abstract class Shape
    {
        public abstract IManipulator CreateManipulator();
        public abstract double BoundlingBox();
    }

    //
    class Line : Shape
    {
        public override IManipulator CreateManipulator()
        {
            return new LineManipulator();
        }

        public override double BoundlingBox()
        {
            return 12.99;
        }
    }

    class TextShape : Shape
    {
        TextView textView = new TextView();

        public override IManipulator CreateManipulator()
        {
            return  new TextManipulator();
        }

        public override double BoundlingBox()
        {
            return textView.GetExtent();
        }

    }

    class  TextView
    {
        public double GetExtent()
        {
            return 10.99;
        }
    }


    interface IManipulator
    {
        
    }

    class  TextManipulator: IManipulator
    {
        
    }

    class LineManipulator : IManipulator
    {

    }

}
