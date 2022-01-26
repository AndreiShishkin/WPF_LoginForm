using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LoginForm.DataAccess
{
    class SqlQuery
    {
        internal const string countLogin = @"SELECT COUNT(*) 
FROM Persons
WHERE Login = @Login AND Password = @Pass";
    }
}
