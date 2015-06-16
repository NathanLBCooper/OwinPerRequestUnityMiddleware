using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OwinPerRequestExample.Objects
{
    public interface IAlwaysTheSame
    {
    }

    public class AlwaysTheSame : IAlwaysTheSame
    {

    }

    public interface ISameInARequest
    {
    }

    public class SameInARequest0 : ISameInARequest
    {

    }

    public interface IAlwaysDifferent
    {
    }

    public class AlwaysDifferent : IAlwaysDifferent
    {

    }

    public interface ISameInRequestDisposible : IDisposable, IReferenceCounting
    {
        void CheckObjectIsNotDisposedWhenWeNeedIt();
    }

    public class SameInRequestDisposible : ISameInRequestDisposible
    {
        private static int Undisposed = 0;
        private bool disposed = false;

        public SameInRequestDisposible()
        {
             Undisposed++;
        }

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;
            Undisposed--;
        }

        ~SameInRequestDisposible()
        {
            this.Dispose();
        }

        public int NumberOfUndisposed
        {
            get
            {
                return Undisposed;
            }
        }

        public void CheckObjectIsNotDisposedWhenWeNeedIt()
        {
            if (!disposed) return;
            throw new ObjectDisposedException("disposed too early");
        }
    }

    public interface IReferenceCounting
    {
        int NumberOfUndisposed { get; }
    }
}