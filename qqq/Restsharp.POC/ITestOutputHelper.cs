using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1
{
    class ITestOutputHelper
    {
        public ITestOutputHelper _output;
        public ITestOutputHelper Output { get { return this._output; } }
        public Demo_Restsharp(ITestOutputHelper output)
        {
            this._output = output;
        }

    }
}
