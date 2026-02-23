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
    public static void DemonstrateFeetEquality()
    {
        Feet feet1 = new Feet(10);
        Feet feet2 = new Feet(10);
        Console.WriteLine(feet1.Equals(feet2));
    }

    public static void Main()
    {
        DemonstrateFeetEquality();
    }
}