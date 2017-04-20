namespace Vega.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.EntityFrameworkCore;

	using AutoMapper;

	using Vega.Data;

	using Make = Model.View.Make;
	using Model = Model.View.Model;
	using Vehicle = Model.View.Vehicle;

	public class VegaRepository : IVegaRepository
	{
		private readonly VegaContext context;
		private readonly IMapper mapper;
		public VegaRepository(VegaContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public IEnumerable<Make> GetMakes()
		{
			var makes = this.context.Makes
				.Include(m => m.Models)
				.ThenInclude(m => m.ModelFeatures)
				.ThenInclude(mf => mf.Feature);

			return makes == null
				? null
				: this.mapper.Map<IEnumerable<Data.Make>, IEnumerable<Make>>(makes);
		}

		public bool ModelExists(int id)
		{
			return this.context.Set<Model>().Any(m => m.Id == id);
		}

		public bool FeatureValidForModel(int modelId, int featureId)
		{
			return this.context.Set<ModelFeature>().Any(mf => mf.ModelId == modelId && mf.FeatureId == featureId);
		}

		public Vehicle CreateVehicle(Vega.Model.Create.Vehicle vehicle)
		{
			if (vehicle == null)
			{
				throw new ArgumentNullException(nameof(vehicle));
			}

		    var vehicleToBeAdded = this.mapper.Map<Data.Vehicle>(vehicle);

			this.context.Vehicles.Add(vehicleToBeAdded);

			return this.mapper.Map<Vehicle>(vehicleToBeAdded);
		}

		public bool DeleteVehicleById(int id)
		{
			var vehicle = this.FindVehicleById(id);

		    if (vehicle == null) return false;

		    this.context.Remove(vehicle);
		    return true;
		}

		public Vehicle GetVehicleById(int id)
		{
			var vehicle = this.context.Vehicles
				.Include(v => v.Model)
				.Include(v => v.VehicleFeatures)
				.FirstOrDefault(v => v.Id == id);

			return vehicle == null 
				? null 
				: this.mapper.Map<Vehicle>(vehicle);
		}

		public IEnumerable<Vehicle> GetVehicles()
		{
			var vehicles = this.context.Vehicles
				.Include(v => v.Model)
				.Include(v => v.VehicleFeatures);

			return vehicles == null
				? null
				: this.mapper.Map<IEnumerable<Data.Vehicle>, IEnumerable<Vehicle>>(vehicles);
		}

		public Vehicle UpdateVehicle(Vega.Model.Update.Vehicle vehicle)
		{
			if (vehicle == null)
			{
				throw new ArgumentNullException(nameof(vehicle));
			}

			var vehicleToUpdate = this.FindVehicleById(vehicle.Id);

			if (vehicleToUpdate == null) return null;

		    this.mapper.Map(vehicle, vehicleToUpdate);

			return this.mapper.Map<Vehicle>(vehicleToUpdate);
		}

		private Data.Vehicle FindVehicleById(int id)
		{
			return this.context.Vehicles.FirstOrDefault(v => v.Id == id);
		}

		public bool Save()
		{
			return (this.context.SaveChanges() >= 0);
		}
	}
}