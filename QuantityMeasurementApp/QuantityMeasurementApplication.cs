
public class QuantityMeasurementApplication{
    public class Feet{
        public double value;
        public Feet(double value){
            this.value = value;
        }
        public double GetValue(){
            return value;
        }
        public override bool Equals(object? obj)
        {
            if(ReferenceEquals(this, obj)) 
                return true;
            
            if(obj==null ||obj.GetType() != this.GetType()) return false;

            Feet feet=(Feet)obj;
            return value.CompareTo(feet.value)==0;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
     
    public class Inch{
        public double value;
        public Inch(double value){
            this.value = value;
        }
        public double GetValue(){
            return value;
        }
        public override bool Equals(object? obj)
        {
            if(ReferenceEquals(this, obj)) 
                return true;
            
            if(obj==null ||obj.GetType() != this.GetType()) return false;

            Inch Inch=(Inch)obj;
            return value.CompareTo(Inch.value)==0;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static void DemonstrateLengthEquality()
{
    QuantityLength q1 = new QuantityLength(1.0, LengthUnit.Yards);
    QuantityLength q2 = new QuantityLength(3.0, LengthUnit.Feet);

    Console.WriteLine($"{q1} and {q2}");
    Console.WriteLine("Equal: " + q1.Equals(q2));

    QuantityLength q3 = new QuantityLength(1.0, LengthUnit.Centimeters);
    QuantityLength q4 = new QuantityLength(0.393701, LengthUnit.Inch);

    Console.WriteLine($"{q3} and {q4}");
    Console.WriteLine("Equal: " + q3.Equals(q4));
}

}