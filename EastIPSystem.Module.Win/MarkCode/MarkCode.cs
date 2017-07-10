using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Win.MarkCode
{
    public enum DataType
    {
        DateTime,
        String,
        Number
    }

    public enum ParaType
    {
        Case,
        File
    }

    public abstract class MarkCode
    {
        public abstract string MarkName { get; }

        public abstract DataType DataType { get; }

        public abstract object GetValue(FileInOfficial fileInOfficial);
    }
}
