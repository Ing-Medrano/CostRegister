using System;

namespace GastosRegisterO.IRepository
{
    public interface IContainer:IDisposable
    {
        IGastosRepository gastosRepository { get; }

        void Save();
    }
}
