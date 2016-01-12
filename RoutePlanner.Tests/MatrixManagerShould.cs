using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoutePlanner.BLL.Services;
using RoutePlanner.Entities;
using RoutePlanner.Entities.Interfaces;
using RoutePlanner.DAL.Contexts;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoutePlanner.Tests
{
    [TestClass]
    public class MatrixManagerShould
    {
        [TestMethod]
        public async Task AddNewAddressAndUpdateMatrix()
        {
            using (var matrixManager = new MatrixManager())
            {
                var newAddress = new Address()
                {
                    FirstLine = "someplace",
                    SecondLine = "over the rainbow",
                    PostCode = "EC4N 8BH",
                    City = "London",
                    Country = "United Kingdom",
                    IsArchived = false,
                    ObjectState = ObjectState.Added
                };

                await matrixManager.InsertOrUpdateAddress(newAddress);


                Address retrieved;
                IEnumerable<MatrixEntry> matrix;

                using (var context = new RpDbContext())
                {
                    retrieved = context.Addresses.FirstOrDefault(a => a.Id == newAddress.Id);

                    matrix = context.MatrixEntries.Where(me => me.OriginId == retrieved.Id || me.DestinationId == retrieved.Id).ToList();

                    Assert.IsTrue(retrieved != null);
                    Assert.IsTrue(matrix.Count() > 0);

                    context.Addresses.Remove(retrieved);

                    context.MatrixEntries.RemoveRange(matrix);

                    context.SaveChanges();
                }
            }
        }
    }
}
