namespace DotnetUpskilling.exception;

/*
 * base() : ini menandakan bahwa message ini didapatkan dari class/parent yang di inherit, dimana message dari custom exception ini akan dikirimkan kembali dan akan dioleh oleh method dari class yang di inherit
 */

public class CustomException : Exception
{
  public CustomException(string? message) : base(message)
  {
  }
}