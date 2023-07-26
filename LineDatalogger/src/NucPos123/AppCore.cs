using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace NucPos123
{
  public class AppCore : IDisposable
  {
    public delegate void AppNotifyHandle(object sender, eNotifyEvent notifyEvent);
    public event AppNotifyHandle OnAppNotifyEvent;

    private static AppCore app;
    public static AppCore Def { get { if (app == null) app = new AppCore(); return app; } set => app = value; }

    public void StartNotifyEvent(eNotifyEvent eNotifyEvent)
    {
      if (OnAppNotifyEvent != null)
      {
        OnAppNotifyEvent(this, eNotifyEvent);
      }
    }

    public enum eNotifyEvent
    {
      LoadConfigurationDone = 0,
    }
    #region IDisposable
    private bool disposedValue;
    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          
        }

        // TODO: free unmanaged resources (unmanaged objects) and override finalizer
        // TODO: set large fields to null
        disposedValue = true;
      }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~App()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
      // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }


    #endregion
  }
}
