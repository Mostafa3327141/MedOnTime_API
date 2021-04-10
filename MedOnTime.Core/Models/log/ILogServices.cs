﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MedOnTime.Core.Models.logSpace
{
    public interface ILogServices
    {
        List<Log> GetLogs();
        Log GetLog(string id);

        Log AddLog(Log log);

        void DeleteLog(string id);

        Log UpdateLog(Log logToUpdate);
    }
}
