﻿using System;
using System.Windows.Input;
 using Lab_04_Romanenko.ViewModels;

 namespace Lab_04_Romanenko.Tools{
    
    public class ProceedCommand : ICommand
    {
        private PersonWindowViewModel _pwvm;
        public ProceedCommand(PersonWindowViewModel pwvm)
        {
            _pwvm = pwvm;
        }

        public bool CanExecute(object parameter)
        {
            return _pwvm.CanProceed();
        }

        public void Execute(object parameter)
        {
            _pwvm.Proceed();
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}