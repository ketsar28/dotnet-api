namespace DotnetUpskilling.abstracts;

public class Triangle : Abstract
{
    public double Base { get; set; }
    public double Height { get; set; }
    public override double GetSurface()
    {
        return 0.5 * Base * Height;
    }
    
}