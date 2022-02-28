using his_lasa_managemenet_service.Models;
using his_lasa_managemenet_service.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Repositories.IRepositories
{
    interface ILasaRepository
    {
        IEnumerable<Lasa> GetAllData_Lasa();
        IEnumerable<Lasa> Search_lasa_byName(string product_name);

        Lasa MapingLasa(Lasa lasa);
        UpdateLasa UpdateLasa(int id,UpdateLasa updateLasa);

        IEnumerable<DataTabelLasa> Tabel_TR_Lasa();


    }
}
