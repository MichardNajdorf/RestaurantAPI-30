﻿using System;

namespace WebApplication4.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) :base(message)
        {

        }
    }
}
