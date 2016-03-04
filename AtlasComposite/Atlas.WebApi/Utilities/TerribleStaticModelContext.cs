using Atlas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atlas.WebApi.Utilities
{
    /// <summary>
    /// This is just a cheap way to store some data temporarily.
    /// </summary>
    public static class TerribleStaticModelContext
    {
        public static List<Process> Processes = new List<Process>();
    }
}