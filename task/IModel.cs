using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    public interface IModel
    {
        // Indexer for accessing array elements.
        int this[int i, int j] { get; set; }

        // Game start time.
        DateTime GameStartTime { get; set; }

        // Game stop time.
        DateTime GameStopTime { get; set; }
    }
}
