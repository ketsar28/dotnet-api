namespace DotnetUpskilling.abstracts;

/*
 * abstract : masih belum jelas/belum tahu implementasinya bagaimana
 * abstract class : bisa menampung sebuah attribute (abstract), dan juga method (abstract)
 *
 * abstract vs virtual : (sama-sama di override)
 * - virual : pewarisan sebuah method/attribute namun tidak wajib di override
 * - abstract : body dari class abstract itu wajib di override di class turunannya
 */

public abstract class Abstract
{
    public string Type { get; set; }
    public abstract double GetSurface();
    
}
