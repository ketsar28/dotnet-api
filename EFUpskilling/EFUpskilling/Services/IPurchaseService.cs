using EFUpskilling.Entities;

namespace EFUpskilling.Services;

public interface IPurchaseService
{
    Purchase CreateTransaction(Purchase purchase);
}