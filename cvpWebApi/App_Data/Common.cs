using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Common
/// </summary>
namespace cvp
{
    public enum ProgramType
    {
        RDS,
        SSR
    }
    public enum WorkType
    {
        search = 0,
        summary = 1
    }

    public enum TaskType
    {
        Create = 0,
        Read = 1,
        Update = 2,
        Delete = 3
    }

    

    public class Common
    {
        public Common()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

   

}