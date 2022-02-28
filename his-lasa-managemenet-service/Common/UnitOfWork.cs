using his_lasa_managemenet_service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        internal DatabaseContext Context;
        private LasaRepository Lasa_Repository;
        private UserRepository User_Repository;
        public UnitOfWork(DatabaseContext _context)
        {
            Context = _context;
        }
        

       
        public UserRepository UnitOfWork_MS_User()
        {
            if (User_Repository == null)
            {
                User_Repository = new UserRepository(Context);
            }
            return User_Repository;
        }

        public LasaRepository UnitOfWork_TR_Lasa()
        {
            //throw new NotImplementedException();
            if(Lasa_Repository == null)
            {
                Lasa_Repository = new LasaRepository();
            }
            return Lasa_Repository;
        }

        //end new data

        public bool Disposing;
        private void DisposingProperties()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        protected virtual void Disposed(bool _disposing)
        {
            if (!Disposing)
            {
                if (_disposing)
                {
                    DisposingProperties();
                }
            }

            Disposing = true;
        }

        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }
    }
}
