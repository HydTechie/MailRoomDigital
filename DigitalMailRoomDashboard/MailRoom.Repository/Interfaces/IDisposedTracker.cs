using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailRoom.Repository.Interfaces
{
    public interface IDisposedTracker
    {
        bool IsDisposed { get; set; }
    }
}
