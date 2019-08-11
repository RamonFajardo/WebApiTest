using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Data
{
    public interface ICarsRepository
    {
        Task<ICollection<Car>> GetCars();

        Task<Car> GetCarByUser(int idUsuario);




    }
}
