﻿using Census.Contracts;

namespace Census.Api.Bff.Logging
{
    public class LogCommand : ICommand
    {
        public const string RouteTemplate = "bff/log";

        public LogEventDto[] LogEvents { get; set; }
    }
}