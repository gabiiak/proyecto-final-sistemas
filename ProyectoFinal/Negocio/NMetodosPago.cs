using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NMetodosPago
    {

         public static List<MetodoPago> GetAll()
    {
        try
        {
            return DataMetodosPago.GetAll();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static List<MetodoPago> GetAllDeleted()
    {
        try
        {
            return DataMetodosPago.GetAllDeletedMetodos();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static void Create(MetodoPago metodoPago)
    {
        try
        {
            DataMetodosPago.Create(metodoPago);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static void Update(MetodoPago metodoPago)
    {
        try
        {
            DataMetodosPago.Update(metodoPago);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static void Delete(MetodoPago metodoPago)
    {
        try
        {
            DataMetodosPago.Delete(metodoPago);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public static void ShowDeletedMetodosPago(MetodoPago metodoPago)
    {
        try
        {
            DataMetodosPago.RestoreMetodoPago(metodoPago);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
}

