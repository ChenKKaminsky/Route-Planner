using RoutePlanner.DAL.Repositories;
using RoutePlanner.Entities;
using RoutePlanner.Entities.Interfaces;
using RoutePlanner.Google;
using RoutePlanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoutePlanner.BLL.Services
{
    public class MatrixManager : IDisposable
    {
        private AddressesRepository _addressRepository;
        private DistanceMatrixApi _matrixApi;
        private MatrixEntriesRepository _matrixRepository;

        public MatrixManager() : this(new DistanceMatrixApi(), new MatrixEntriesRepository(), new AddressesRepository())
        {

        }

        public MatrixManager(DistanceMatrixApi matrixApi, MatrixEntriesRepository matrixRepository, AddressesRepository addressRepository)
        {
            _matrixApi = matrixApi;
            _matrixRepository = matrixRepository;
            _addressRepository = addressRepository;
        }

        public async Task InsertOrUpdateAddress(Address address)
        {
            switch (address.ObjectState)
            {
                case ObjectState.Unchanged:
                    break;
                case ObjectState.Added:
                    _addressRepository.InsertOrUpdate(address);
                    _addressRepository.SaveChanges();
                    await CreateMatrixForNewAddress(address.Id);
                    break;
                case ObjectState.Modified:
                    _addressRepository.InsertOrUpdate(address);
                    _addressRepository.SaveChanges();
                    await UpdateRelatedMatrixEntries(address.Id);
                    break;
                case ObjectState.Deleted:
                    _addressRepository.Remove(address);
                    _addressRepository.SaveChanges();
                    RemoveRelatedMatrixEntries(address.Id);
                    break;
                default:
                    break;
            }
            _addressRepository.SaveChanges();
            _matrixRepository.SaveChanges();
        }

        public void RemoveRelatedMatrixEntries(int addressId)
        {
            var entries = _matrixRepository.GetList(e => e.OriginId == addressId || e.DestinationId == addressId);

            if (entries.Count() < 1)
            {
                throw new Exception("No entries were found for the specified record");
            }

            _matrixRepository.Remove(entries.ToArray());
        }

        public async Task CreateMatrixForNewAddress(int addressId)
        {
            var newAddress = _addressRepository.GetSingle(a => a.Id == addressId);
            var addresses = _addressRepository.All();

            foreach (var address in addresses)
            {
                try
                {
                    var fromNew = new MatrixEntry() { OriginId = newAddress.Id, DestinationId = address.Id, ObjectState = ObjectState.Added };
                    fromNew.Value = await GetUpdatedMatrixEntryValue(newAddress, address);
                    var toNew = new MatrixEntry() { OriginId = address.Id, DestinationId = newAddress.Id, ObjectState = ObjectState.Added };
                    toNew.Value = await GetUpdatedMatrixEntryValue(address, newAddress);

                    _matrixRepository.InsertOrUpdate(new MatrixEntry[] { fromNew, toNew });
                }
                catch (Exception)
                {

                    throw;
                }

            }

        }

        public async Task UpdateRelatedMatrixEntries(int addressId)
        {
            var entries = _matrixRepository.GetList(e => e.OriginId == addressId || e.DestinationId == addressId);

            if (entries.Count() < 1)
            {
                return;
            }

            foreach (var entry in entries)
            {
                var org = _addressRepository.GetSingle(a => a.Id == entry.OriginId);
                var dst = _addressRepository.GetSingle(a => a.Id == entry.DestinationId);

                try
                {
                    entry.Value = await GetUpdatedMatrixEntryValue(org, dst);
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        private async Task<int> GetUpdatedMatrixEntryValue(Address origin, Address destinatoin)
        {
            var parameters = new DistanceMatrixParameters();
            parameters.Origins.Add(origin.ToString());
            parameters.Destinations.Add(destinatoin.ToString());

            ServiceResponse<int> response;
            try
            {
                response = await _matrixApi.GetAddressInfoAsync(parameters, InfoType.Duration);
                if (response.Success)
                {
                    return response.Value;
                }
            }
            catch (Exception)
            {
                throw;
            }
            throw new Exception("Could not get service response");
        }

        bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                //clear managed code
            }
            //clear unmanaged code

            //supress finilize
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~MatrixManager()
        {
            Dispose(false);
        }
    }
}
