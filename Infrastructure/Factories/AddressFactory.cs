

using Infrastructure.Entities;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Factories;


public class AddressFactory
{
    public static AddressEntity Create()
    {
        try
        {
            return new AddressEntity();

        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public static AddressEntity Create(string Addressline_1, string postalCode, string city)
    {
        try
        {
            return new AddressEntity
            {
                AddressLine_1 = Addressline_1,
                PostalCode = postalCode,
                City = city
            };
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }

    public static AddressModel Create(AddressEntity entity)
    {
        try
        {
            return new AddressModel
            {
                Id = entity.Id,
                Addressline_1 = entity.AddressLine_1,
                PostalCode = entity.PostalCode,
                City = entity.City
            };

        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }
}