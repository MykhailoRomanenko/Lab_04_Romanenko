﻿using System;

namespace Lab_04_Romanenko.Tools.Exceptions
{
    public class UserIsProbablyDeadException : Exception
    {
        public UserIsProbablyDeadException(String msg):base(msg)
        {
            
        }
    }
}