﻿using System;
using System.Transactions;

namespace Lab_04_Romanenko.Tools.Exceptions
{
    public class InvalidEMailException: Exception
    {
      public  InvalidEMailException(String msg):base(msg)
      {
        }
    }
}