using Datos;
using Modelos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NEmpleado
    {
        public static int RegistrarEmpleado(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException(nameof(empleado), "Los datos del empleado no pueden ser nulos.");

            if (string.IsNullOrWhiteSpace(empleado.Nombre))
                throw new ArgumentException("El nombre del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Apellido))
                throw new ArgumentException("El apellido del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Cargo))
                throw new ArgumentException("El cargo del empleado es obligatorio.");

            if (empleado.NumCuenta <= 0)
                throw new ArgumentException("El número de cuenta debe ser válido.");

            if (empleado.Sueldo < 0)
                throw new ArgumentException("El sueldo no puede ser un valor negativo.");

            if (empleado.FechaIngreso == DateTime.MinValue)
                empleado.FechaIngreso = DateTime.Today;

            // Por defecto se registra en estado activo (1)
            empleado.Activo = 1;

            return DataEmpleado.CreateEmpleado(empleado);
        }

        public static List<Empleado> ListarEmpleados(bool soloActivos = true)
        {
            return DataEmpleado.GetAllEmpleados(soloActivos);
        }

        public static Empleado ObtenerPorId(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("El identificador del empleado no es válido.");

            return DataEmpleado.GetEmpleadoById(idEmpleado);
        }

        public static void ModificarEmpleado(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException(nameof(empleado), "Los datos del empleado no pueden ser nulos.");

            if (empleado.IdEmpleado <= 0)
                throw new ArgumentException("El identificador del empleado no es válido.");

            if (string.IsNullOrWhiteSpace(empleado.Nombre))
                throw new ArgumentException("El nombre del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Apellido))
                throw new ArgumentException("El apellido del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Cargo))
                throw new ArgumentException("El cargo del empleado es obligatorio.");

            if (empleado.NumCuenta <= 0)
                throw new ArgumentException("El número de cuenta debe ser válido.");

            if (empleado.Sueldo < 0)
                throw new ArgumentException("El sueldo no puede ser un valor negativo.");

            Empleado existente = DataEmpleado.GetEmpleadoById(empleado.IdEmpleado);
            if (existente == null)
                throw new InvalidOperationException("El empleado que intenta modificar no existe.");

            DataEmpleado.UpdateEmpleado(empleado);
        }

        // Baja lógica
        public static void DesactivarEmpleado(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("El identificador del empleado no es válido.");

            Empleado empleado = DataEmpleado.GetEmpleadoById(idEmpleado);
            if (empleado == null)
                throw new InvalidOperationException("El empleado a desactivar no existe.");

            DataEmpleado.DesactivarEmpleado(idEmpleado);
        }

        // Baja física
        public static void EliminarEmpleado(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("El identificador del empleado no es válido.");

            Empleado empleado = DataEmpleado.GetEmpleadoById(idEmpleado);
            if (empleado == null)
                throw new InvalidOperationException("El empleado a eliminar no existe.");

            DataEmpleado.EliminarEmpleado(idEmpleado);
        }
    }
}