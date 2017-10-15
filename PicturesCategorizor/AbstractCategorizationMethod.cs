/**********************************
 * Copyright 2017 Netium
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturesCategorizor
{
    abstract class AbstractCategorizationMethod
    {
        public string Parameter { get; private set; }

        public AbstractCategorizationMethod(string parameter)
        {
            Parameter = parameter ?? string.Empty;
        }
        public abstract string GetTargetFolder(string mediaFile);
    }
}
