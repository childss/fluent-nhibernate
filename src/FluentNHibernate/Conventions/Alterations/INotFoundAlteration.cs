using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHibernate.Conventions.Alterations
{
    public interface INotFoundAlteration
    {
        void Ignore();
        void Exception();
    }
}
