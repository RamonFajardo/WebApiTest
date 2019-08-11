using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Data
{
    public class CarsRepository : ICarsRepository
    {

        #region Variables privadas

        private readonly DataContext _context;

        #endregion

        #region Constructores

        public CarsRepository(DataContext context)
        {
            _context = context;
        }

        #endregion



        #region Metodos Privados

        public Task<ICollection<Car>> GetCars()
        {
            throw new NotImplementedException();
        }

        public async Task<Car> GetCarByUser(int idUsuario)
        {
            return await _context.Cars.Where(x => x.Usuario.ID == idUsuario).FirstOrDefaultAsync();
        }

      
        #endregion

    }
}
