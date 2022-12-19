using ErrorOr;

namespace TechTestDDD.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Vehicle
        {
            public static Error Validation => Error.Validation(
                code: "Vehicle.Validation",
                description: "Parametros requeridos son obligatorios.");

            public static Error Conflict => Error.Conflict(
                code: "Vehicle.Conflict",
                description: "No existe el registro que busca.");
        }
    }
}
