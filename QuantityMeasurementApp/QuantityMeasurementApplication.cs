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
    public static void DemonstrateInchEquality()
    {
        Inch Inch1 = new Inch(10);
        Inch Inch2 = new Inch(10);
        Console.WriteLine(Inch1.Equals(Inch2));
    }

    public static void Main()
    {
        DemonstrateInchEquality();
    }
}