using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ContactApp.Data.Common
{
    public static class FunctionClass
    {
        public static string DataTableToJSON(DataTable dt)
        {
            string str =  JsonConvert.SerializeObject(dt, Formatting.None);
            return JsonConvert.SerializeObject(dt, Formatting.None);
        }
    }
}
