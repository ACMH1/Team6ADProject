﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SSexception
/// </summary>
public class SSexception : Exception
{
    public SSexception()
    {
    }

    public SSexception(string message)
    : base(message)
    {
    }

    public SSexception(string message, Exception inner)
    : base(message, inner)
    {
    }
}