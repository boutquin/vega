namespace Vega.Services
{
    using System.Collections.Generic;

    using Vega.Model.View;

    public interface IVegaRepository
    {
        // API: /api/makes/ GET
        IEnumerable<Make> GetMakes();

        bool ModelExists(int id);
        bool FeatureValidForModel(int modelId, int featureId);

        // API: /api/vehicles/ POST
        Vehicle CreateVehicle(Vega.Model.Create.Vehicle vehicle);
        // API: /api/vehicles/ GET
        IEnumerable<Vehicle> GetVehicles();
        // API: /api/vehicles/{id} GET
        Vehicle GetVehicleById(int id);
        // API: /api/vehicles/ PUT
        Vehicle UpdateVehicle(Vega.Model.Update.Vehicle vehicle);
        // API: /api/vehicles/{id} DELETE
        bool DeleteVehicleById(int id);

        bool Save();
    }
}