using System.Collections.Generic;

namespace SiteMapConsole.Models
{
    public interface IHaveLocationElements
    {
        IEnumerable<IHaveALocationElement> Locations { get; }
    }
}