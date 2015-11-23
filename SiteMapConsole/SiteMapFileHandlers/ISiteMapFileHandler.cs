using System;
using SiteMapConsole.Models;

namespace SiteMapConsole.SiteMapFileHandlers
{
    public interface ISiteMapFileHandler
    {
        void Process(Action<IHaveALocationElement> urlHandler);
    }
}