namespace DotnetUpskilling.abstracts;
/*
 * kita wajib implementasikan method milik dari abstract classnya
 */
public class Rectangle : Abstract
{
    public double Width { get; set; }
    public double Length { get; set; }
    public override double GetSurface()
    {
        return Width * Length;
    }
    
}