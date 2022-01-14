using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testwork
{
    public interface IDeserializer
    {
        public Task<string[]> StrArrayReturn(string filePath);
    }
}
